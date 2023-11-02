using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YifyFileDownloader.Models.DataModels;

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
    [Column("API_RESPONSE", TypeName = "VARCHAR(MAX)")]
    public string Response { get; set; }
}
