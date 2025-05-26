using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using YifyApi.Extensions;
using YifyCommon.Extensions;
using YifyCommon.Persistence;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddLogging(config => config.AddConsole());
// Add services to the container.
Log.Logger = BuildLogger(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(config =>
{
    config.AddSerilog();
});

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
});

builder.Services.AddDbContext<YTSDbContext>(options =>
{
    string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:LocalDb") ?? string.Empty;
    options.UseSqlite(connectionString);
});

builder.Services.AddServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

Serilog.Core.Logger BuildLogger(IConfiguration configuration)
{
    var settings = configuration.GetSerilogSettings();
    var restrictedToLevel = settings.SerilogMinimumLevel.ToEnum<LogEventLevel>();
    var rollingIntervalValue = settings.SerilogRollingInterval.ToEnum<RollingInterval>();

    return new LoggerConfiguration()
                    // add console as logging target
                    .WriteTo.Console()
                    // add a rolling file for all logs
                    .WriteTo.File(settings.SerilogFilePath,
                                  restrictedToMinimumLevel: restrictedToLevel,
                                  rollingInterval: rollingIntervalValue,
                                  shared: settings.SerilogFileSharedBoolean,
                                  fileSizeLimitBytes: settings.SerilogFileSizeLimitBytesLong,
                                  rollOnFileSizeLimit: settings.SerilogRollOnFileSizeLimitBoolean)
                    // set default minimum level
                    .MinimumLevel.Information()
                    .CreateLogger();
}