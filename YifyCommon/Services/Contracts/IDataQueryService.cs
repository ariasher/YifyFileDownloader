using System.Linq.Expressions;
using YifyCommon.Models.Constants;

namespace YifyCommon.Services.Contracts
{
    public interface IDataQueryService<T> where T : class, Models.DataModels.Contracts.IModel
    {
        // Get by ID
        T Get(long id);
        T Get<TProperty>(long id, Expression<Func<T, TProperty>> include);

        // Async Get by ID
        Task<T> GetAsync(long id);
        Task<T> GetAsync<TProperty>(long id, Expression<Func<T, TProperty>> include);

        // Get All
        IEnumerable<T> GetAll(DataOrder order = DataOrder.None);
        IEnumerable<T> GetAll<TProperty>(Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        IEnumerable<T> GetAll(int limit, DataOrder order = DataOrder.None);
        IEnumerable<T> GetAll<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        IEnumerable<T> GetAll(int limit, int page, DataOrder order = DataOrder.None);
        IEnumerable<T> GetAll<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        // Get All Active
        IEnumerable<T> GetAllActive(DataOrder order = DataOrder.None);
        IEnumerable<T> GetAllActive<TProperty>(Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        IEnumerable<T> GetAllActive(int limit, DataOrder order = DataOrder.None);
        IEnumerable<T> GetAllActive<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        IEnumerable<T> GetAllActive(int limit, int page, DataOrder order = DataOrder.None);
        IEnumerable<T> GetAllActive<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        // Async Get All
        Task<IEnumerable<T>> GetAllAsync(DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        Task<IEnumerable<T>> GetAllAsync(int limit, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllAsync<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        Task<IEnumerable<T>> GetAllAsync(int limit, int page, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllAsync<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        // Async Get All Active
        Task<IEnumerable<T>> GetAllActiveAsync(DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllActiveAsync<TProperty>(Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        Task<IEnumerable<T>> GetAllActiveAsync(int limit, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllActiveAsync<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);

        Task<IEnumerable<T>> GetAllActiveAsync(int limit, int page, DataOrder order = DataOrder.None);
        Task<IEnumerable<T>> GetAllActiveAsync<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None);
    }
}
