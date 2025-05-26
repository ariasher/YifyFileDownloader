using YifyApi.Utilities.Helpers.ControllerHelpers;
using YifyCommon.Repositories;
using YifyCommon.Repositories.Contracts;
using YifyCommon.Services;
using YifyCommon.Services.Contracts;

namespace YifyApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<DataControllerHelper>();
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            service.AddScoped(typeof(IRepositoryQueryable<>), typeof(RepositoryQueryable<>));
            service.AddScoped(typeof(IRepositoryContainer<>), typeof(RepositoryContainer<>));
            service.AddScoped(typeof(IDataManipulationService<>), typeof(Service<>));
            service.AddScoped(typeof(IDataManipulationServiceAsync<>), typeof(Service<>));
            service.AddScoped(typeof(IDataQueryService<>), typeof(Service<>));
            service.AddScoped<IMovieDetailsService, MovieDetailsService>();
            service.AddScoped<ITorrentDetailsService, TorrentDetailsService>();
        }
    }
}
