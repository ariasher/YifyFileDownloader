using Microsoft.Extensions.Logging;
using YifyCommon.Exceptions;
using YifyCommon.Models.ApiModels;
using YifyCommon.Models.DataModels;
using YifyCommon.Models.HelperModels;
using YifyCommon.Persistence;
using Newtonsoft.Json;

namespace YifyCommon.Services
{
    public class ApiService
    {
        private HttpClient _client;
        private ApiSettings _settings;
        private ILogger<ApiService> _logger;
        private YTSDbContext _context;

        public ApiService(ApiSettings settings, ILogger<ApiService> logger, YTSDbContext context)
        {
            _context = context;
            _logger = logger;
            _settings = settings;
            _client = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true,
                SslProtocols = System.Security.Authentication.SslProtocols.Tls | System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls12
            });
        }

    public async Task<ApiMoviesResponse?> GetApiMoviesResponse(int page)
    {
        try
        {
            _logger.LogInformation("Calling the API for movie information.");

            var payloadQueryString = GetQueryString(page);
            _logger.LogInformation($"Payload generated : {payloadQueryString}");

            string finalUrl = $"{_settings.Endpoint}/?{payloadQueryString}";
            _logger.LogInformation($"Calling API Endpoint : {finalUrl}");

            var response = await _client.GetAsync(finalUrl);

            if (response == null)
                throw new ApiException("Calling endpoint with data resulted in null response.");

            if (response?.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ApiException($"Calling endpoint with data result in {response?.StatusCode} status code.");

            var responseData = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"API Response received.");

            _logger.LogInformation("Logging information to the database.");
            API api = new API()
            {
                CreatedAt = DateTime.Now,
                Endpoint = _settings.Endpoint,
                Name = "Movies",
                Payload = payloadQueryString,
                UpdatedAt = DateTime.Now,
                Response = responseData
            };

            await _context.AddAsync(api);
            _context.SaveChanges();
            _logger.LogInformation("Saved information in the database.");

            var finalResponse = JsonConvert.DeserializeObject<ApiMoviesResponse>(responseData);
            return finalResponse;
        }
        catch
        {
            throw;
        }
    }

    private string GetQueryString(int page)
    {
        List<string> queryStringParams = new List<string>();

        string limitQueryString = $"limit={_settings.Limit}";
        string pageQueryString = $"page={page}";
        //string qualityQueryString = $"quality={_settings.Qualities}";
        string minRatingQueryString = $"minimum_rating={_settings.MinimumRating}";
        //string genreQueryString = $"genre={_settings.Genres}";

        queryStringParams.Add(limitQueryString);
        queryStringParams.Add(pageQueryString);
        //queryStringParams.Add(qualityQueryString);
        queryStringParams.Add(minRatingQueryString);
        //queryStringParams.Add(genreQueryString);

        return string.Join("&", queryStringParams);
    }
}
}
