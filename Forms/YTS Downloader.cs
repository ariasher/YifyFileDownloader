using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YifyFileDownloader.Exceptions;
using YifyFileDownloader.Models.ApiModels;
using YifyFileDownloader.Models.DataModels;
using YifyFileDownloader.Models.HelperModels;
using YifyFileDownloader.Persistence;
using YifyFileDownloader.Services;
using YifyFileDownloader.Utilities;

namespace YifyFileDownloader.Forms
{
    public partial class YTS_Downloader : Form
    {
        private YTSDbContext _context;
        private ILogger<YTS_Downloader> _logger;
        private ApiService _apiService;
        
        public YTS_Downloader(YTSDbContext context, ILogger<YTS_Downloader> logger, ILogger<ApiService> serviceLogger, ApiSettings apiSettings)
        {
            InitializeComponent();
            _context = context;
            _logger = logger;
            _apiService = new ApiService(apiSettings, serviceLogger, context);
        }

        private async Task btnDownload_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            InstanceLog instanceLog = new InstanceLog
            {
                CreatedAt = now,
                UpdatedAt = now,
                IsSuccess = false
            };

            try
            {
                infoLabel.Text = "Download is going to start.";
                _logger.LogInformation("Download is going to start.");

                int page = 1;
                bool reachedLastRead = false;

                // Fetch when was the last time this program ran successfully.
                var lastRunDateTime = _context.InstanceLogs
                    .OrderByDescending(i => i.Id)
                    .Where(i => i.IsSuccess)
                    .FirstOrDefault()?.CreatedAt;

                int lastMovieId = _context.MovieDetails
                    .OrderBy(m => m.Id)
                    .Where(m => m.CreatedAt == lastRunDateTime)
                    .AsNoTracking()
                    .FirstOrDefault()?.MId ?? 0;

                while (!reachedLastRead)
                {
                    _logger.LogInformation("API loop started.");
                    infoLabel.Text = "Started calling API.";

                    var apiResponse = await _apiService.GetApiMoviesResponse(page);
                    _logger.LogInformation($"API response received for page {page}.");

                    (bool hasMovieId, List<MovieDetails> movieDetails) = MapApiData(apiResponse, lastMovieId, now);
                    _logger.LogInformation($"API response mapped for page {page}.");
                    _logger.LogInformation($"Saving details to the DB.");

                    await _context.AddRangeAsync(movieDetails);
                    _context.SaveChanges();
                    _logger.LogInformation($"Saved details to the DB.");

                    // Wait for 5 seconds to refetch data of the next page
                    ++page;
                    _logger.LogInformation($"Going to sleep for 5 seconds.");
                    Thread.Sleep(5000);
                }

                _logger.LogInformation("Download finished. Data is upto-date.");
                infoLabel.Text = "Download finished. Data is upto-date.";
                Dialog.ShowMessage(Utility.TitleSuccess, "Download finished.", Dialog.Type.Information);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to download data.");
                _logger.LogError($"Exception : {ex} with message {ex.Message}.");
                infoLabel.Text = ex.Message;
                instanceLog.UpdatedAt = DateTime.Now;
                Dialog.ShowMessage(Utility.TitleError, "An error occurred while downloading data. Please try again or check log files.", Dialog.Type.Error);
            }

            try
            {
                _logger.LogInformation("Saving instance log.");
                await SaveInstanceLog(instanceLog);
                _logger.LogInformation("Intance log saved.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving instance log.");
                _logger.LogError($"Exception : {ex} with message {ex.Message}.");
            }
        }


        private async Task SaveInstanceLog(InstanceLog log)
        {
            await _context.AddAsync(log);
            _context.SaveChanges();
        }

        private (bool HasLastMovieId, List<MovieDetails> Movies) 
            MapApiData(ApiMoviesResponse moviesResponse, int lastMovieId, DateTime instanceTime)
        {
            if (moviesResponse.data == null || moviesResponse.data.movie_count == 0)
                throw new ApiException("Movies does not contain any movie data.");

            List<MovieDetails> movies = new List<MovieDetails>();
            bool hasLastMovieId = false;

            foreach (var movie in moviesResponse.data.movies)
            {
                if (movie.id == lastMovieId)
                {
                    _logger.LogInformation($"Last movie Id found {movie.id}.");
                    hasLastMovieId = true;
                    break;
                }

                if (movie.torrents == null || movie.torrents.Count == 0)
                {
                    _logger.LogInformation($"No torrent for movie {movie.id} - {movie.title}.");
                    continue;
                }

                var movieDetails = new MovieDetails();
                movieDetails.Title = movie.title;
                movieDetails.EnglishTitle = movie.title_english;
                movieDetails.Genres = string.Join(",", movie.genres);
                movieDetails.CreatedAt = instanceTime;
                movieDetails.ImdbCode = movie.imdb_code;
                movieDetails.Language = movie.language;
                movieDetails.LongTitle = movie.title_long;
                movieDetails.MId = movie.id;
                movieDetails.Rating = movie.rating;
                movieDetails.Runtime = movie.runtime;
                movieDetails.UpdatedAt = instanceTime;
                movieDetails.Url = movie.url;
                movieDetails.Year = movie.year;

                movieDetails.Torrents = new List<TorrentDetails>();

                foreach (var torrent in movie.torrents)
                {
                    var torrentDetails = new TorrentDetails
                    {
                        CreatedAt = instanceTime,
                        Hash = torrent.hash,
                        Quality = torrent.quality,
                        Type = torrent.type,
                        UpdatedAt = instanceTime,
                        URL = torrent.url
                    };

                    movieDetails.Torrents.Add(torrentDetails);
                }
                
                movies.Add(movieDetails);
            }

            return (hasLastMovieId, movies); 
        }
    }
}
