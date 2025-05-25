using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Repositories.Contracts;

namespace YifyCommon.Repositories
{
    public class RepositoryContainer<T> : IRepositoryContainer<T> where T: class, IModel
    {
        public IRepository<T> Repository { get; private set; }

        public IRepositoryAsync<T> RepositoryAwaitable { get; private set; }

        public IRepositoryQueryable<T> Query { get; set; }

        public RepositoryContainer(IRepository<T> repository, IRepositoryAsync<T> respositoryAwaitable, IRepositoryQueryable<T> repositoryQueryable)
        {
            Repository = repository;
            RepositoryAwaitable = respositoryAwaitable;
            Query = repositoryQueryable;
        }
    }
}
