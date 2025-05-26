namespace YifyApi.Models.Transit.Response.Contracts
{
    public interface IResponseDTO
    {
        string Status { get; set; }
        
        string Message { get; set; }
        
        object? Data { get; set; }
    }
}
