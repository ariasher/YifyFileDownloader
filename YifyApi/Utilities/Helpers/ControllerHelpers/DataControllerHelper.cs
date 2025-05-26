using YifyApi.Models.Transit.Request;
using YifyCommon.Models.DataModels;
using YifyCommon.Services.Contracts;
using YifyCommon.Models.Constants;

namespace YifyApi.Utilities.Helpers.ControllerHelpers
{
    public class DataControllerHelper
    {
        private readonly IMovieDetailsService _movieDetailsService;
        private readonly ITorrentDetailsService _torrentDetailsService;

        public DataControllerHelper(IMovieDetailsService movieDetailsService, ITorrentDetailsService torrentDetailsService)
        {
            _movieDetailsService = movieDetailsService;
            _torrentDetailsService = torrentDetailsService;
        }

        // TODO change type
        public async Task<IEnumerable<MovieDetails>> GetMovies(BaseRequestDTO requestDTO)
        {
            var movies = await _movieDetailsService.GetAllActiveAsync(requestDTO.Limit, requestDTO.Page, DataOrder.Ascending);
            return movies;
        }

    }
}
