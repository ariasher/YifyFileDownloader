using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Repositories.Contracts;
using YifyCommon.Services.Contracts;

namespace YifyCommon.Services
{
    public class Service<T> : QueryableService<T>, IDataManipulationService<T>, IDataManipulationServiceAsync<T> where T: class, IModel
    {
        protected readonly IRepository<T> _repository;
        protected readonly IRepositoryAsync<T> _repositoryAwaitable;

        public Service(IRepositoryContainer<T> container) : base(container.Query)
        {
            _repository = container.Repository;
            _repositoryAwaitable = container.RepositoryAwaitable;
        }

        public void AddRecord(T model)
        {
            try
            {
                _repository.Add(model);
                _repository.Commit();
            }
            catch
            {
                throw;
            }
        }

        public async Task AddRecordAsync(T model)
        {
            try
            {
                await _repositoryAwaitable.AddAsync(model);
                await _repositoryAwaitable.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteRecord(T model)
        {
            try
            {
                _repository.Delete(model);
                _repository.Commit();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteRecord(long id)
        {
            try
            {
                var model = Get(id);
                _repository.Delete(model);
                _repository.Commit();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRecordAsync(T model)
        {
            try
            {
                await _repositoryAwaitable.DeleteAsync(model);
                await _repositoryAwaitable.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRecordAsync(long id)
        {
            try
            {
                var model = Get(id);
                await _repositoryAwaitable.DeleteAsync(model);
                await _repositoryAwaitable.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateRecord(T model)
        {
            try
            {
                _repository.Update(model);
                _repository.Commit();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRecordAsync(T model)
        {
            try
            {
                await _repositoryAwaitable.UpdateAsync(model);
                await _repositoryAwaitable.CommitAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
