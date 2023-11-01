using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyFileDownloader.Models.DataModels;

public class MovieDetails : BaseModel
{
    [Required]
    [Column("MOVIE_ID")]
    public int MId { get; set; }

    [Required]
    [Column("MOVIE_URL")]
    [StringLength(200)]
    public string Url { get; set; }

    [Required]
    [Column("MOVIE_TITLE")]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [Column("MOVIE_ENGLISH_TITLE")]
    [StringLength(100)]
    public string EnglishTitle { get; set; }

    [Required]
    [Column("MOVIE_LONG_TITLE")]
    [StringLength(200)]
    public string LongTitle { get; set; }

    [Required]
    [Column("IMDB_CODE")]
    [StringLength(50)]
    public string ImdbCode { get; set; }

    [Required]
    [Column("RELEASE_YEAR")]
    public int Year { get; set; }

    [Required]
    [Column("RATING")]
    public double Rating { get; set; }

    [Required]
    [Column("MOVIE_LENGTH")]
    public int Runtime { get; set; }

    [Required]
    [Column("GENRES")]
    [StringLength(100)]
    public string Genres { get; set; }

    [Required]
    [Column("MOVIE_LANGUAGE")]
    [StringLength(20)]
    public string Language { get; set; }

    [NotMapped]
    public List<TorrentDetails> Torrents { get; set; }
}
