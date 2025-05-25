namespace YifyCommon.Repositories.Contracts
{
    public interface IRepository<T> where T: Models.DataModels.Contracts.IModel
    {
        void Add(T model);

        void Update(T model);

        void Delete(T model);

        bool Commit();

        void Rollback();
    }
}
