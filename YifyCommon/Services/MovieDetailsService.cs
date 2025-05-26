using YifyCommon.Models.DataModels;
using YifyCommon.Repositories.Contracts;
using YifyCommon.Services.Contracts;

namespace YifyCommon.Services
{
    public class MovieDetailsService : Service<MovieDetails>, IMovieDetailsService
    {
        public MovieDetailsService(IRepositoryContainer<MovieDetails> container) : base(container)
        {
        }
    }
}
