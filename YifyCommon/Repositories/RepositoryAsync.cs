using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YifyCommon.Exceptions;
using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Persistence;
using YifyCommon.Repositories.Contracts;

namespace YifyCommon.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class, IModel
    {
        private int _dirtyWritesCount;
        private bool _transactionInitiated;
        private readonly YTSDbContext _dbContext;

        public RepositoryAsync(YTSDbContext dbContext)
        {
            _dbContext = dbContext;
            _dirtyWritesCount = 0;
            _transactionInitiated = false;
        }

        private async Task InitiateTransactionIfNewAsync()
        {
            if (!_transactionInitiated)
            {
                await _dbContext.Database.BeginTransactionAsync();
                _transactionInitiated = true;
            }
        }

        public async Task AddAsync(T model)
        {
            await InitiateTransactionIfNewAsync();
            await _dbContext.AddAsync(model);
            _dirtyWritesCount += 1;
        }

        public async Task<bool> CommitAsync()
        {
            if (_dirtyWritesCount > 0)
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Database.CommitTransactionAsync();
                    return true;
                }
                catch
                {
                    await _dbContext.Database.RollbackTransactionAsync();
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

        public async Task DeleteAsync(int id)
        {
            await InitiateTransactionIfNewAsync();
            var model = await GetAsync(id);
            _dbContext.Remove(model);
            _dirtyWritesCount += 1;
        }

        public async Task<T> GetAsync(long id)
        {
            if (id <= 0)
                throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

            var model = await _dbContext.Set<T>().FirstOrDefaultAsync(m => m.Id == id);

            if (model == null)
                throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

            return model;
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool all)
        {
            IQueryable<T> dbSet = _dbContext.Set<T>();

            if (!all)
                dbSet = dbSet.Where(m => m.IsActive == true);

            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool all, Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> dbSet = _dbContext.Set<T>();

            if (!all)
                dbSet = dbSet.Where(m => m.IsActive == true);

            if (predicate != null)
                dbSet = dbSet.Where(predicate);

            return await dbSet.ToListAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transactionInitiated)
            {
                await _dbContext.Database.RollbackTransactionAsync();
                _transactionInitiated = false;
            }

            _dirtyWritesCount = 0;
        }

        public async Task UpdateAsync(T model)
        {
            await InitiateTransactionIfNewAsync();
            _dbContext.Update(model);
            _dirtyWritesCount += 1;
        }
    }
}
