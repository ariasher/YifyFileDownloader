using System.Data.Common;
using YifyCommon.Models.DataModels.Contracts;

namespace YifyCommon.Repositories.Contracts
{
    internal interface IRepositoryAsync<T> where T: IModel
    {
        Task<int> AddAsync(T model);

        Task<int> UpdateAsync(T model);

        Task<int> DeleteAsync(int id);

        Task<T> GetAsync(long id);

        Task<IEnumerable<T>> GetAllAsync(bool all);

        Task<IEnumerable<T>> GetAllAsync(bool all, Func<IModel, bool> predicate);

        Task<bool> CommitAsync();

        Task<DbConnection> GetDbConnectionAsync();
    }
}
