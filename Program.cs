using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Configuration;
using YifyFileDownloader.Forms;
using YifyFileDownloader.Persistence;
using YifyFileDownloader.Services;
using YifyFileDownloader.Utilities;

namespace YifyFileDownloader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var host = Startup.BuildHost();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var formLogger = services.GetRequiredService<ILogger<YTS_Downloader>>();
                    var dbContext = services.GetRequiredService<YTSDbContext>();
                    var apiLogger = services.GetRequiredService<ILogger<ApiService>>();
                    var apiSettings = Startup.GetApiSettings();

                    ApplicationConfiguration.Initialize();
                    Application.Run(new YTS_Downloader(dbContext, formLogger, apiLogger, apiSettings));
                }
                catch (Exception ex)
                {
                    Dialog.ShowMessage(Utility.TitleError, "An error occurred while opening the application. Please try again or check log files.", Dialog.Type.Error);
                }
            }
        }
    }
}