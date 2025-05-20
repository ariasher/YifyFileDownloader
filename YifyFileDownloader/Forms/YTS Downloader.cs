using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using YifyCommon.Exceptions;
using YifyFileDownloader.Models.YifyApiModels;
using YifyCommon.Models.DataModels;
using YifyFileDownloader.Models.HelperModels;
using YifyCommon.Persistence;
using YifyFileDownloader.Services;
using YifyFileDownloader.Utilities;

namespace YifyFileDownloader.Forms
{
    public partial class YTS_Downloader : Form
    {
        private YTSDbContext _context;
        private ILogger<YTS_Downloader> _logger;
        private ApiService _apiService;
        private bool mouseDown;
        private Point lastLocation;
        private int sleepSeconds;
        private int sleepMilliseconds;
        private int page;

        public YTS_Downloader(YTSDbContext context, ILogger<YTS_Downloader> logger, ILogger<ApiService> serviceLogger, ApiSettings apiSettings)
        {
            InitializeComponent();
            rtbStatus.Text = "Ready to Start.";
            lblTitle.Text = "Yify Movies Downloader";
            _context = context;
            _logger = logger;
            _apiService = new ApiService(apiSettings, serviceLogger, context);

            sleepMilliseconds = apiSettings.SleepMilliseconds;
            sleepSeconds = Convert.ToInt32(Math.Ceiling(apiSettings.SleepMilliseconds / 1000f));
            page = apiSettings.Page;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                var now = DateTime.Now;
                InstanceLogs instanceLog = new InstanceLogs
                {
                    CreatedAt = now,
                    UpdatedAt = now,
                    IsSuccess = false
                };

                try
                {
                    btnDownload.PerformSafely(() => btnDownload.Enabled = false);
                    AddLineToTheTextbox("Download is going to start.");
                    _logger.LogInformation("Download is going to start.");

                    bool reachedLastRead = false;
                    bool hadMoviesToAdd = false;

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
                        AddLineToTheTextbox($"Started calling API. Page {page}.");

                        var apiResponse = await _apiService.GetApiMoviesResponse(page);
                        _logger.LogInformation($"API response received for page {page}.");

                        (bool hasMovieId, List<MovieDetails> movieDetails) = MapApiData(apiResponse, lastMovieId, now);
                        _logger.LogInformation($"API response mapped for page {page}.");
                        _logger.LogInformation($"Saving details to the DB.");

                        if (movieDetails.Count > 0 && !hadMoviesToAdd)
                            hadMoviesToAdd = true;

                        await _context.AddRangeAsync(movieDetails);
                        _context.SaveChanges();
                        _logger.LogInformation($"Saved details to the DB.");

                        // Wait for 10 seconds to refetch data of the next page
                        ++page;
                        reachedLastRead = reachedLastRead || hasMovieId;
                        _logger.LogInformation($"Going to sleep for {sleepSeconds} seconds.");
                        AddLineToTheTextbox($"Going to sleep for {sleepSeconds} seconds.");
                        Thread.Sleep(sleepMilliseconds);
                    }

                    _logger.LogInformation("Download finished. Data is upto-date.");

                    page = 1;
                    instanceLog.IsSuccess = reachedLastRead && hadMoviesToAdd;
                    AddLineToTheTextbox("Download finished. Data is upto-date.");
                    Dialog.ShowMessage(Utility.TitleSuccess, "Download finished.", Dialog.Type.Information);
                    btnDownload.PerformSafely(() => btnDownload.Enabled = true);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while trying to download data.");
                    _logger.LogError($"Exception : {ex} with message {ex.Message}.");
                    AddLineToTheTextbox(ex.Message);
                    page = 1;
                    instanceLog.UpdatedAt = DateTime.Now;
                    Dialog.ShowMessage(Utility.TitleError, "An error occurred while downloading data. Please try again or check log files.", Dialog.Type.Error);
                    btnDownload.PerformSafely(() => btnDownload.Enabled = true);
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
            });
        }

        private void AddLineToTheTextbox(string line)
        {
            rtbStatus.PerformSafely(() => {
                string message = $"{line}{Environment.NewLine}{rtbStatus.Text}";

                if (message.Length > rtbStatus.MaxLength)
                {
                    message = $"Maximum length reached for textbox. Clearing it.";
                    message = $"{line}{Environment.NewLine}{message}";
                }

                rtbStatus.Text = message;
            });
        }

        private async Task SaveInstanceLog(InstanceLogs log)
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
                movieDetails.Genres = string.Join(",", movie.genres ?? new List<string>());
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

        /// <summary>
        /// Helper method to determin if invoke required, if so will rerun method on correct thread.
        /// if not do nothing.
        /// </summary>
        /// <param name="c">Control that might require invoking</param>
        /// <param name="a">action to preform on control thread if so.</param>
        /// <returns>true if invoke required</returns>
        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate () { a(); }));
            else return false;

            return true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Do you really want to exit?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmation == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void YTS_Downloader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void YTS_Downloader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void YTS_Downloader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
