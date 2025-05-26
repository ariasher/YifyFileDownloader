using YifyApi.Models.Transit.Request;
using YifyCommon.Models.DataModels;
using YifyCommon.Services.Contracts;
using YifyCommon.Models.Constants;
using YifyApi.Models.DTOs;
using AutoMapper;

namespace YifyApi.Utilities.Helpers.ControllerHelpers
{
    public class DataControllerHelper
    {
        private readonly IMovieDetailsService _movieDetailsService;
        private readonly ITorrentDetailsService _torrentDetailsService;
        private readonly IMapper _mapper;

        public DataControllerHelper(IMovieDetailsService movieDetailsService, ITorrentDetailsService torrentDetailsService, IMapper mapper)
        {
            _movieDetailsService = movieDetailsService;
            _torrentDetailsService = torrentDetailsService;
            _mapper = mapper;
        }

        // TODO change type
        public async Task<IEnumerable<MovieDTO>> GetMovies(BaseRequestDTO requestDTO)
        {
            var movies = await _movieDetailsService.GetAllActiveAsync(requestDTO.Limit, requestDTO.Page, DataOrder.Ascending);
            var moviesDto = _mapper.Map<IEnumerable<MovieDTO>>(movies);
            
            return moviesDto;
        }

    }
}
