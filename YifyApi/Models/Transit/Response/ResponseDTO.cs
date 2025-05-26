namespace YifyApi.Models.Transit.Response
{
    public class ResponseDTO
    {
        public required string Status { get; set; }
        public required string Message { get; set; }
        public object? Data { get; set; }
    }
}
