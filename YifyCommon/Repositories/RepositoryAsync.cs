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

        public async Task DeleteAsync(T model)
        {
            await InitiateTransactionIfNewAsync();
            _dbContext.Remove(model);
            _dirtyWritesCount += 1;
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
