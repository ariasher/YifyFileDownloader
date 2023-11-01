using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Configuration;
using YifyFileDownloader.Forms;
using YifyFileDownloader.Persistence;
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

            var host = BuildHost();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var logg = services.GetRequiredService<ILogger<YTS_Downloader>>();
                    var employeeContext = services.GetRequiredService<YTSDbContext>();
                    // check for startup actions

                    ApplicationConfiguration.Initialize();
                    //Application.Run(new Form1());

                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }


                
        }

        private static IHost BuildHost()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings[Utility.ConnectionStringName]
                .ToString();

            var builder = new HostBuilder()
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddDbContext<YTSDbContext>(options =>
                  {
                      options.UseSqlServer(connectionString);
                  });

                  var serilogLogger = BuildLogger();

                  services.AddLogging(x =>
                  {
                      x.SetMinimumLevel(LogLevel.Information);
                      x.AddSerilog(logger: serilogLogger, dispose: true);
                  });


                  //services.AddScoped<>();
              });

            return builder.Build();
        }

        private static Serilog.ILogger BuildLogger()
        {
            return new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();
        }
    }
}