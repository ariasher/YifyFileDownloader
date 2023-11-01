using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YifyFileDownloader.Models.Constants;

namespace YifyFileDownloader.Models.HelperModels;

public class ApiSettings
{
    // Default values based on the API specifications
    private const int DEFAULT_LIMIT = 20;
    private const string DEFAULT_GENRE = nameof(MovieGenre.All);

    // Addition default values
    private const int DEFAULT_MIN_YEAR = 1980;
    private const string DEFAULT_QUALITY = $"{nameof(MovieQuality.FHD1080p)},{nameof(MovieQuality.HD720p)}";
    private const double DEFAULT_MIN_RATING = 5;
    
    // Properties
    public int MinimumYear { get; set; }
    public int Limit { get; set; }
    public string Qualities { get; set; }
    public double MinimumRating { get; set; }
    public string Genres { get; set; }
    public string Endpoint { get; set; }

    public ApiSettings(NameValueCollection AppSettings)
    {
        var minYear = AppSettings[nameof(MinimumYear)];
        var limit = AppSettings[nameof(Limit)];
        var qualities = AppSettings[nameof(Qualities)];
        var minRating = AppSettings[nameof(MinimumRating)];
        var genres = AppSettings[nameof(Genres)];
        var endpoint = AppSettings[nameof(Endpoint)];

        MinimumYear = string.IsNullOrWhiteSpace(minYear) ? DEFAULT_MIN_YEAR : Convert.ToInt32(minYear);
        Limit = string.IsNullOrWhiteSpace(limit) ? DEFAULT_LIMIT : Convert.ToInt32(limit);
        MinimumRating = string.IsNullOrWhiteSpace(minRating) ? DEFAULT_MIN_RATING : Convert.ToInt32(minRating);
        Qualities = string.IsNullOrWhiteSpace(qualities) ? DEFAULT_QUALITY : qualities;
        Genres = string.IsNullOrWhiteSpace(genres) ? DEFAULT_GENRE : genres;
        Endpoint = endpoint ?? string.Empty;
    }
}
