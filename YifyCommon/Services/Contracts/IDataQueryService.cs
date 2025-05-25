using YifyCommon.Models.Constants;

namespace YifyCommon.Services.Contracts
{
    public interface IDataQueryService<T> where T : class, Models.DataModels.Contracts.IModel
    {
        T Get(long id);
        IEnumerable<T> GetAll(DataOrder order = DataOrder.None);
        IEnumerable<T> GetAll(int limit, DataOrder order = DataOrder.None);
        IEnumerable<T> GetAll(int limit, int page, DataOrder order = DataOrder.None);
        IEnumerable<T> GetAllActive(DataOrder order = DataOrder.None);
        IEnumerable<T> GetAllActive(int limit, DataOrder order = DataOrder.None);
        IEnumerable<T> GetAllActive(int limit, int page, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllAsync(DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllAsync(int limit, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllAsync(int limit, int page, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllActiveAsync(DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllActiveAsync(int limit, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllActiveAsync(int limit, int page, DataOrder order = DataOrder.None);
    }
}
