using System.ComponentModel.DataAnnotations;
using YifyApi.Models.Transit.Request.Contracts;

namespace YifyApi.Models.Transit.Request
{
    public class BaseRequestDTO : IRequestDTO
    {
        [Required]
        public int Limit { get; set; }

        [Required]
        public int Page { get; set; }
    }
}
