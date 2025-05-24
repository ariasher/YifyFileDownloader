using Microsoft.EntityFrameworkCore;
using YifyApi.Models.Transit.Request;
using YifyCommon.Models.DataModels;
using YifyCommon.Persistence;

namespace YifyApi.Utilities.Helpers.ControllerHelpers
{
    public class DataControllerHelper
    {
        // TODO replace with services
        private readonly YTSDbContext _dbContext;
        public DataControllerHelper(YTSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO change type
        public async Task<IEnumerable<MovieDetails>> GetMovies(BaseRequestDTO requestDTO)
        {
            return await _dbContext.MovieDetails.OrderBy(m => m.Id).Skip((requestDTO.Page - 1) < 0 ? 0 : requestDTO.Page - 1).Take(requestDTO.Limit).ToListAsync();
        }

    }
}
