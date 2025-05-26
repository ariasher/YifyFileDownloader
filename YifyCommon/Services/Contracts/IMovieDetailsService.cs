namespace YifyCommon.Services.Contracts
{
    public interface IMovieDetailsService : IDataManipulationServiceAsync<Models.DataModels.MovieDetails>, 
        IDataQueryService<Models.DataModels.MovieDetails>
    {
        

    }
}
