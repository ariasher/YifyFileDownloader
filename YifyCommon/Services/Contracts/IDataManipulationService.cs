namespace YifyCommon.Services.Contracts
{
    public interface IDataManipulationService<T> where T: class, Models.DataModels.Contracts.IModel
    {
        void AddRecord(T model);
        void UpdateRecord(T model);
        void DeleteRecord(T model);
        void DeleteRecord(long id);
    }
}
