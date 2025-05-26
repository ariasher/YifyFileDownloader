using YifyCommon.Models.Utilities;

namespace YifyApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static SerilogSettings GetSerilogSettings(this IConfiguration configuration)
        {
            var settings = new SerilogSettings();
            settings.SerilogMinimumLevel = configuration.GetValue<string>("Serilog:MinimumLevel") ?? "Information";
            settings.SerilogUsingFile = configuration.GetValue<string>("Serilog:UsingFile") ?? "Serilog.Sinks.File";
            settings.SerilogFilePath = configuration.GetValue<string>("Serilog:FilePath") ?? ".\\Logs\\log.txt";
            settings.SerilogFileShared = configuration.GetValue<string>("Serilog:FileShared") ?? "true";
            settings.SerilogRollOnFileSizeLimit = configuration.GetValue<string>("Serilog:RollOnFileSizeLimit") ?? "true";
            settings.SerilogRollingInterval = configuration.GetValue<string>("Serilog:RollingInterval") ?? "Day";
            settings.SerilogFileSizeLimitBytes = configuration.GetValue<string>("Serilog:FileSizeLimitBytes") ?? "16777216";

            return settings;
        }
    }
}
