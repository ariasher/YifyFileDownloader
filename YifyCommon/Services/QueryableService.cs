using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YifyCommon.Exceptions;
using YifyCommon.Extensions;
using YifyCommon.Models.Constants;
using YifyCommon.Models.DataModels.Contracts;
using YifyCommon.Repositories.Contracts;
using YifyCommon.Services.Contracts;

namespace YifyCommon.Services
{
    public class QueryableService<T> : IDataQueryService<T> where T : class, IModel
    {
        protected readonly IRepositoryQueryable<T> _queryRepository;

        public QueryableService(IRepositoryQueryable<T> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public T Get(long id)
        {
            try
            {
                if (id <= 0)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                var model = _queryRepository.GetAll(false).Where(r => r.Id == id).FirstOrDefault();

                if (model == null)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                return model;
            }
            catch
            {
                throw;
            }
        }

        public T Get<TProperty>(long id, Expression<Func<T, TProperty>> include)
        {
            try
            {
                if (id <= 0)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                var model = _queryRepository.GetAll(false).Where(r => r.Id == id).Include(include).FirstOrDefault();

                if (model == null)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> GetAsync(long id)
        {
            try
            {
                if (id <= 0)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                var model = await _queryRepository.GetAll(false).Where(r => r.Id == id).FirstOrDefaultAsync();

                if (model == null)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> GetAsync<TProperty>(long id, Expression<Func<T, TProperty>> include)
        {
            try
            {
                if (id <= 0)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                var model = await _queryRepository.GetAll(false).Where(r => r.Id == id).Include(include).FirstOrDefaultAsync();

                if (model == null)
                    throw new InvalidDataModelException($"The Data Model: {typeof(T)} with id: {id} is invalid.");

                return model;
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
                var records = _queryRepository.GetAll(true).ApplyDataOrder(order);
                return records.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll<TProperty>(Expression<Func<T,TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(true).Include(include).ApplyDataOrder(order);
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

        public IEnumerable<T> GetAll<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return GetAll(limit, 1, include, order);
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

                var records = _queryRepository.GetAll(true).ApplyDataOrder(order).Paginate(page, limit);
                return records.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(true).Include(include).ApplyDataOrder(order).Paginate(page, limit);
                return records.ToList();
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
                var records = _queryRepository.GetAll(false).ApplyDataOrder(order);
                return records.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAllActive<TProperty>(Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(false).Include(include).ApplyDataOrder(order);
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

        public IEnumerable<T> GetAllActive<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return GetAllActive(limit, 1, include, order);
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

                var records = _queryRepository.GetAll(false).ApplyDataOrder(order).Paginate(page, limit);
                return records.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAllActive<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(false).Include(include).ApplyDataOrder(order).Paginate(page, limit);
                return records.ToList();
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
                var records = _queryRepository.GetAll(false).ApplyDataOrder(order);
                return await records.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync<TProperty>(Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(false).Include(include).ApplyDataOrder(order);
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

        public async Task<IEnumerable<T>> GetAllActiveAsync<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return await GetAllActiveAsync(limit, 1, include, order);
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

                var records = _queryRepository.GetAll(false).ApplyDataOrder(order).Paginate(page, limit);
                return await records.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(false).Include(include).ApplyDataOrder(order).Paginate(page, limit);
                return await records.ToListAsync();
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
                var records = _queryRepository.GetAll(true).ApplyDataOrder(order);
                return await records.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<TProperty>(Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                var records = _queryRepository.GetAll(true).Include(include).ApplyDataOrder(order);
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

        public async Task<IEnumerable<T>> GetAllAsync<TProperty>(int limit, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 0)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                return await GetAllAsync(limit, 1, include, order);
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

                var records = _queryRepository.GetAll(true).ApplyDataOrder(order).Paginate(page, limit);
                return await records.ToListAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<IEnumerable<T>> GetAllAsync<TProperty>(int limit, int page, Expression<Func<T, TProperty>> include, DataOrder order = DataOrder.None)
        {
            try
            {
                if (limit < 1)
                    throw new InvalidDataException($"The limit parameter with value {limit} is invalid.");

                if (page < 1)
                    throw new InvalidDataException($"The page parameter with value {page} is invalid.");

                var records = _queryRepository.GetAll(true).Include(include).ApplyDataOrder(order).Paginate(page, limit);
                return await records.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
