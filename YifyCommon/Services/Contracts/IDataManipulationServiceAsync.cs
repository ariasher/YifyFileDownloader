namespace YifyCommon.Services.Contracts
{
    public interface IDataManipulationServiceAsync<T> where T : class, Models.DataModels.Contracts.IModel
    {
        Task AddRecordAsync(T model);
        Task UpdateRecordAsync(T model);
        Task DeleteRecordAsync(T model);
        Task DeleteRecordAsync(long id);
    }
}
