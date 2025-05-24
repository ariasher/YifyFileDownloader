using YifyApi.Models.Transit.Request.Contracts;

namespace YifyApi.Models.Transit.Request
{
    public class BaseRequestDTO : IRequestDTO
    {
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}
