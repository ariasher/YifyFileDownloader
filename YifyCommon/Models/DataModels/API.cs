using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YifyCommon.Models.DataModels;

[Index(nameof(IsActive))]
[Index(nameof(DeletedAt))]
[Index(nameof(CreatedAt))]
[Table("API")]
public class API : BaseModel
{
    [Required]
    [MaxLength(100)]
    [Column("API_NAME")]
    public string Name { get; set; }

    [Required]
    [MaxLength(200)]
    [Column("API_ENDPOINT")]
    public string Endpoint { get; set; }

    [Required]
    [MaxLength(400)]
    [Column("API_PAYLOAD")]
    public string Payload { get; set; }

    [Required]
    [Column("API_RESPONSE")]
    public string Response { get; set; }
}
