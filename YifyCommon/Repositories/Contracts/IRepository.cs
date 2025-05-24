using System.Data.Common;
using YifyCommon.Models.DataModels.Contracts;

namespace YifyCommon.Repositories.Contracts
{
    public interface IRepository<T> where T: IModel
    {
        int Add(T model);

        int Update(T model);

        int Delete(int id);

        T Get(long id);

        IEnumerable<T> GetAll(bool all);

        IEnumerable<T> GetAll(bool all, Func<IModel, bool> predicate);

        bool Commit();

        DbConnection GetDbConnection();
    }
}
