using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YifyFileDownloader.Models.DataModels;

[Table("TORRENT_DETAILS")]
public class TorrentDetails : BaseModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(200)]
    public string URL { get; set; }

    [Required]
    public int Year { get; set; }

    [Required]
    [StringLength(50)]
    public string Genre { get; set; }

    [Required]
    public double Rating { get; set; }

    [Required]
    public long TorrentId { get; set; }
}
