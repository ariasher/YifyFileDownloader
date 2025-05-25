using System.Linq.Expressions;
using YifyCommon.Exceptions;
using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Persistence;
using YifyCommon.Repositories.Contracts;

namespace YifyCommon.Repositories
{
    public class RepositoryQueryable<T> : IRepositoryQueryable<T> where T : class, IModel
    {
        private readonly YTSDbContext _dbContext;

        public RepositoryQueryable(YTSDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public IQueryable<T> GetAll(bool all)
        {
            var dbSet = _dbContext.Set<T>().AsQueryable();

            if (!all)
                dbSet = dbSet.Where(m => m.IsActive == true);

            return dbSet;
        }

        public IQueryable<T> GetAll(bool all, Expression<Func<T, bool>>? predicate = null)
        {
            var dbSet = _dbContext.Set<T>().AsQueryable();

            if (!all)
                dbSet = dbSet.Where(m => m.IsActive == true);

            if (predicate != null)
                dbSet = dbSet.Where(predicate);

            return dbSet;
        }
    }
}
