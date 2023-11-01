using Microsoft.EntityFrameworkCore;
using YifyFileDownloader.Models.DataModels;

namespace YifyFileDownloader.Persistence;

public class YTSDbContext : DbContext
{
    public YTSDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovieDetails>()
            .HasMany(m => m.Torrents)
            .WithOne(t => t.MovieDetails)
            .HasForeignKey(t => t.MovieId)
            .HasPrincipalKey(m => m.Id);
    }


    public DbSet<API> APIs { get; set; }
    public DbSet<MovieDetails> MovieDetails { get; set; }
    public DbSet<TorrentDetails> TorrentDetails { get; set; }
}
