using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YifyFileDownloader.Models.DataModels;

[Table("API")]
public class API : BaseModel
{
    [Required]
    [StringLength(100)]
    public string ApiName { get; set; }

    [Required]
    [StringLength(200)]
    public string ApiEndpoint { get; set; }

    [Required]
    [StringLength(400)]
    public string Payload { get; set; }

    [Required]
    [StringLength(2000)]
    public string Response { get; set; }
}
