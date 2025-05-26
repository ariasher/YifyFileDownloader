using YifyCommon.Models.Constants;
using YifyCommon.Models.DataModels.Contracts;

namespace YifyCommon.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyDataOrder<T>(this IQueryable<T> query, DataOrder order)
            where T : class, IModel
        {
            return order switch
            {
                DataOrder.Ascending => query.OrderBy(r => r.Id),
                DataOrder.Descending => query.OrderByDescending(r => r.Id),
                _ => query
            };
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int limit) 
            where T : class, IModel
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10; // default limit if invalid

            int skip = (page - 1) * limit;
            return query.Skip(skip).Take(limit);
        }
    }
}
