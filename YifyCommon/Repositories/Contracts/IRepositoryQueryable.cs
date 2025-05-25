namespace YifyCommon.Repositories.Contracts
{
    public interface IRepositoryQueryable<T> where T: class, Models.DataModels.Contracts.IModel
    {
        T Get(long id);
        IQueryable<T> GetAll(bool all);

        IQueryable<T> GetAll(bool all, System.Linq.Expressions.Expression<Func<T, bool>>? predicate);
    }
}
