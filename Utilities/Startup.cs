using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YifyFileDownloader.Persistence;
using YifyFileDownloader.Models.HelperModels;

namespace YifyFileDownloader.Utilities
{
    internal class Startup
    {

        // check whether db file exists
        // if not create db file and generate tables

        public static IHost BuildHost()
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

        public static ApiSettings GetApiSettings()
        {
            ApiSettings settings = new ApiSettings(ConfigurationManager.AppSettings);
            return settings;
        }
    }
}
