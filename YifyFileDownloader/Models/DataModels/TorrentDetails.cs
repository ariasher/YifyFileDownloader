using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YifyFileDownloader.Models.DataModels;

[Index(nameof(IsActive))]
[Index(nameof(DeletedAt))]
[Index(nameof(CreatedAt))]
[Index(nameof(Quality))]
[Index(nameof(Type))]
[Index(nameof(MovieId))]
[Table("TORRENT_DETAILS")]
public class TorrentDetails : BaseModel
{
    [Required]
    [MaxLength(200)]
    [Column("TORRENT_URL")]
    public string URL { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("TORRENT_HASH")]
    public string Hash { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("TORRENT_QUALITY")]
    public string Quality { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("TORRENT_TYPE")]
    public string Type { get; set; }

    [Required]
    [Column("MOVIE_ID")]
    public long MovieId { get; set; }

    [NotMapped]
    public MovieDetails MovieDetails { get; set; }
}
