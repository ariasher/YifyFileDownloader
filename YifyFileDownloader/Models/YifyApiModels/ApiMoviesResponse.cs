namespace YifyFileDownloader.Models.YifyApiModels;

public class ApiMoviesResponse : BaseResponse
{
    public ApiMovieSummary? data { get; set; }
}
