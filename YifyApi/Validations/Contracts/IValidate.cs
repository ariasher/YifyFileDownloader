namespace YifyApi.Validations.Contracts
{
    public interface IValidate<T> where T: class, Models.Transit.Request.Contracts.IRequestDTO
    {
        Models.Validations.ValidationResult Validate(T request);
    }
}
