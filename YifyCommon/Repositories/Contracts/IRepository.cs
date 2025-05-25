namespace YifyCommon.Repositories.Contracts
{
    public interface IRepository<T> where T: Models.DataModels.Contracts.IModel
    {
        void Add(T model);

        void Update(T model);

        void Delete(long id);

        void Delete(T model);

        T Get(long id);

        IEnumerable<T> GetAll(bool all);

        IEnumerable<T> GetAll(bool all, System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        bool Commit();

        void Rollback();
    }
}
