namespace YifyCommon.Repositories.Contracts
{
    public interface IRepositoryContainer<T> where T: class, Models.DataModels.Contracts.IModel
    {
        IRepository<T> Repository { get; }
        IRepositoryAsync<T> RepositoryAwaitable { get; }
        IRepositoryQueryable<T> Query { get; }
    }
}
