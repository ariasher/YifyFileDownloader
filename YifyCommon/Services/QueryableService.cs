using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Repositories.Contracts;
using YifyCommon.Services.Contracts;

namespace YifyCommon.Services
{
    public class QueryableService<T> : IDataQueryService<T> where T : class, IModel
    {
        private readonly IRepositoryQueryable<T> _queryRepository;

        public QueryableService(IRepositoryQueryable<T> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public T Get(long id)
        {
            try
            {
                return _queryRepository.Get(id);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                var records = _queryRepository.GetAll(true);
                return records;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAllActive()
        {
            try
            {
                var records = _queryRepository.GetAll(false);
                return records;
            }
            catch
            {
                throw;
            }
        }
    }
}
