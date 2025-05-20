using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YifyFileDownloader.Models.DataModels;

public abstract class BaseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public long Id { get; set; }

    [Required]
    [Column("IS_ACTIVE")]
    public bool? IsActive { get; set; }

    [Column("DELETED_AT")]
    public DateTime? DeletedAt { get; set; }

    [Required]
    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; }
}
