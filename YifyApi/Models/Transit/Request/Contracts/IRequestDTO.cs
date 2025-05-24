namespace YifyApi.Models.Transit.Request.Contracts
{
    public interface IRequestDTO
    {
        int Limit { get; set; }
        int Page {  get; set; }
    }
}
