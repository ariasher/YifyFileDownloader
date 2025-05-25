using Microsoft.EntityFrameworkCore;
using YifyCommon.Models.Constants;
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

        public IEnumerable<T> GetAll(DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(true);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return records.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll(int limit, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return GetAll(limit, 1, order);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll(int limit, int page, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(true);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return records.Skip(page - 1).Take(limit).ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAllActive(DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(false);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return records.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAllActive(int limit, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return GetAllActive(limit, 1, order);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAllActive(int limit, int page, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(false);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return records.Skip(page - 1).Take(limit).ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync(DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(false);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return await records.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync(int limit, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return await GetAllActiveAsync(limit, 1, order);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync(int limit, int page, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(false);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return await records.Skip(page - 1).Take(limit).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(true);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return await records.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(int limit, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return await GetAllAsync(limit, 1, order);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(int limit, int page, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(true);

                records = order switch
                {
                    DataOrder.Ascending => records.OrderBy(r => r.Id),
                    DataOrder.Descending => records.OrderByDescending(r => r.Id),
                    _ => records
                };

                return await records.Skip(page - 1).Take(limit).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
