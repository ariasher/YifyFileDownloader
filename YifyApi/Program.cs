using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using YifyApi.Utilities.Helpers.ControllerHelpers;
using YifyCommon.Persistence;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddLogging(config => config.AddConsole());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
});

builder.Services.AddDbContext<YTSDbContext>(options =>
{
    string connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:LocalDb");
    options.UseSqlite(connectionString);
});
builder.Services.AddScoped<DataControllerHelper>();

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
