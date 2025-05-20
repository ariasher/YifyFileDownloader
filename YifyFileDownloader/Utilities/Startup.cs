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
using Serilog.Events;
using Serilog.Formatting.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YifyFileDownloader.Utilities
{
    internal class Startup
    {

        // check whether db file exists
        // if not create db file and generate tables

        public static IHost BuildHost(Serilog.ILogger Logger)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings[Utility.ConnectionStringName]
                .ToString();

            var builder = new HostBuilder()
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddDbContext<YTSDbContext>(options =>
                  {
                      options.UseSqlite(connectionString);
                      //options.UseSqlServer(connectionString);
                  });

                  var serilogLogger = BuildLogger();
                  Logger = serilogLogger;

                  services.AddLogging(x =>
                  {
                      //x.SetMinimumLevel(LogLevel.Information);
                      x.AddSerilog(logger: serilogLogger, dispose: false);
                  });
              });

            return builder.Build();
        }

        private static Serilog.Core.Logger BuildLogger()
        {
            var filePath = ConfigurationManager.AppSettings[Utility.SerilogFilePath];
            var minLevel = ConfigurationManager.AppSettings[Utility.SerilogMinimumLevel];
            var restrictedToLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), minLevel);
            var rollingInterval = ConfigurationManager.AppSettings[Utility.SerilogRollingInterval];
            var rollingIntervalValue = (RollingInterval)Enum.Parse(typeof(RollingInterval), rollingInterval);
            var fileShared = Convert.ToBoolean(ConfigurationManager.AppSettings[Utility.SerilogFileShared]);
            var fileRollOn = Convert.ToBoolean(ConfigurationManager.AppSettings[Utility.SerilogRollOnFileSizeLimit]);
            var fileSize = Convert.ToInt64(ConfigurationManager.AppSettings[Utility.SerilogFileSizeLimitBytes]);


            return new LoggerConfiguration()
            // add console as logging target
                            .WriteTo.Console()
            // add a rolling file for all logs
                            .WriteTo.File(filePath,
                                          restrictedToMinimumLevel: restrictedToLevel,
                                          rollingInterval: rollingIntervalValue,
                                          shared: fileShared,
                                          fileSizeLimitBytes: fileSize,
                                          rollOnFileSizeLimit: fileRollOn)
                            // set default minimum level
                            .MinimumLevel.Debug()
                            .CreateLogger();
        }

        public static ApiSettings GetApiSettings()
        {
            ApiSettings settings = new ApiSettings(ConfigurationManager.AppSettings);
            return settings;
        }
    }
}
