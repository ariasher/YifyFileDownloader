using Microsoft.EntityFrameworkCore;
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
