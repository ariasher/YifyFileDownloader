using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Repositories.Contracts;

namespace YifyCommon.Repositories
{
    public class RepositoryContainer<T> : IRepositoryContainer<T> where T: class, IModel
    {
        public IRepository<T> Repository { get; private set; }

        public IRepositoryAsync<T> RepositoryAsync { get; private set; }

        public RepositoryContainer(IRepository<T> repository, IRepositoryAsync<T> repositoryAsync)
        {
            Repository = repository;
            RepositoryAsync = repositoryAsync;
        }
    }
}
