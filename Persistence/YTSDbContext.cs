using Microsoft.EntityFrameworkCore;
using YifyFileDownloader.Extensions;
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

        modelBuilder.Entity<API>().Property(b => b.IsActive).HasDefaultValue(true);
        modelBuilder.Entity<MovieDetails>().Property(b => b.IsActive).HasDefaultValue(true);
        modelBuilder.Entity<TorrentDetails>().Property(b => b.IsActive).HasDefaultValue(true);
        modelBuilder.Entity<InstanceLogs>().Property(b => b.IsActive).HasDefaultValue(true);

        modelBuilder.Entity<API>().Property(b => b.Response).HasColumnType("blob");
    }

    public override int SaveChanges()
    {
        this.AutoTruncateStringToMaxLength();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        this.AutoTruncateStringToMaxLength();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        this.AutoTruncateStringToMaxLength();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        this.AutoTruncateStringToMaxLength();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public DbSet<API> APIs { get; set; }
    public DbSet<MovieDetails> MovieDetails { get; set; }
    public DbSet<TorrentDetails> TorrentDetails { get; set; }
    public DbSet<InstanceLogs> InstanceLogs { get; set; }
}
