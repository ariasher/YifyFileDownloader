using YifyCommon.Exceptions;
using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Persistence;
using YifyCommon.Repositories.Contracts;
using System.Linq.Expressions;

namespace YifyCommon.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IModel
    {
        private int _dirtyWritesCount;
        private bool _transactionInitiated;
        private readonly YTSDbContext _dbContext;

        public Repository(YTSDbContext dbContext)
        {
            _dbContext = dbContext;
            _dirtyWritesCount = 0;
            _transactionInitiated = false;
        }

        private void InitiateTransactionIfNew()
        {
            if (!_transactionInitiated)
            {
                _dbContext.Database.BeginTransaction();
                _transactionInitiated = true;
            }
        }

        public void Add(T model)
        {
            InitiateTransactionIfNew();
            _dbContext.Add(model);
            _dirtyWritesCount += 1;
        }

        public bool Commit()
        {
            if (_dirtyWritesCount > 0)
            {
                try
                {
                    _dbContext.SaveChanges();
                    _dbContext.Database.CommitTransaction();
                    return true;
                }
                catch
                {
                    _dbContext.Database.RollbackTransaction();
                    throw;
                }
                finally
                {
                    _transactionInitiated = false;
                    _dirtyWritesCount = 0;
                }
            }

            return false;
        }

        public void Delete(long id)
        {
            var model = Get(id);
            Delete(model);
        }

        public void Delete(T model)
        {
            InitiateTransactionIfNew();
            _dbContext.Remove(model);
            _dirtyWritesCount += 1;
        }

        public T Get(long id)
        {
            if (id <= 0)
                throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

            var model = _dbContext.Set<T>().Where(m => m.Id == id).FirstOrDefault();

            if (model == null)
                throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

            return model;
        }

        public IEnumerable<T> GetAll(bool all)
        {
            var dbSet = _dbContext.Set<T>().AsQueryable();

            if (!all)
                dbSet = dbSet.Where(m => m.IsActive == true);

            return dbSet.ToList();
        }

        public IEnumerable<T> GetAll(bool all, Expression<Func<T, bool>> predicate = null)
        {
            var dbSet = _dbContext.Set<T>().AsQueryable();

            if (!all)
                dbSet = dbSet.Where(m => m.IsActive == true);

            if (predicate != null)
                dbSet = dbSet.Where(predicate);

            return dbSet.ToList();
        }

        public void Rollback()
        {
            if (_transactionInitiated)
            {
                _dbContext.Database.RollbackTransaction();
                _transactionInitiated = false;
            }

            _dirtyWritesCount = 0;
        }

        public void Update(T model)
        {
            InitiateTransactionIfNew();
            _dbContext.Update(model);
            _dirtyWritesCount += 1;
        }
    }
}
