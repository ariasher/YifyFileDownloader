namespace YifyCommon.Repositories.Contracts
{
    public interface IRepositoryAsync<T> where T: Models.DataModels.Contracts.IModel
    {
        Task AddAsync(T model);

        Task UpdateAsync(T model);

        Task DeleteAsync(long id);

        Task DeleteAsync(T model);

        Task<T> GetAsync(long id);

        Task<IEnumerable<T>> GetAllAsync(bool all);

        Task<IEnumerable<T>> GetAllAsync(bool all, System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        Task<bool> CommitAsync();

        Task RollbackAsync();
    }
}
