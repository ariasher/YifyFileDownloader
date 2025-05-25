namespace YifyCommon.Repositories.Contracts
{
    public interface IRepositoryAsync<T> where T: Models.DataModels.Contracts.IModel
    {
        Task AddAsync(T model);

        Task UpdateAsync(T model);

        Task DeleteAsync(T model);

        Task<bool> CommitAsync();

        Task RollbackAsync();
    }
}
