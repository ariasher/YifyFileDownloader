using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Persistence;
using YifyCommon.Repositories.Contracts;

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

        public void Delete(T model)
        {
            InitiateTransactionIfNew();
            _dbContext.Remove(model);
            _dirtyWritesCount += 1;
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
