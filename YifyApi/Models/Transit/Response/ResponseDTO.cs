using YifyApi.Models.Transit.Response.Contracts;

namespace YifyApi.Models.Transit.Response
{
    public class ResponseDTO: IResponseDTO
    {
        public required string Status { get; set; }
        public required string Message { get; set; }
        public object? Data { get; set; }
    }
}
