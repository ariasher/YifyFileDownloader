using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YifyFileDownloader.Models.DataModels;

[Table("TORRENT_DETAILS")]
public class TorrentDetails : BaseModel
{
    [Required]
    [StringLength(200)]
    [Column("TORRENT_URL")]
    public string URL { get; set; }

    [Required]
    [StringLength(100)]
    [Column("TORRENT_HASH")]
    public string Hash { get; set; }

    [Required]
    [StringLength(50)]
    [Column("TORRENT_QUALITY")]
    public string Quality { get; set; }

    [Required]
    [StringLength(50)]
    [Column("TORRENT_TYPE")]
    public string Type { get; set; }

    [Required]
    [Column("MOVIE_ID")]
    public int MovieId { get; set; }

    [NotMapped]
    public MovieDetails MovieDetails { get; set; }
}
