namespace YifyCommon.Services.Contracts
{
    public interface IDataQueryService<T> where T : class, Models.DataModels.Contracts.IModel
    {
        T Get(long id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllActive();
    }
}
