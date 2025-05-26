namespace YifyApi.Models.Validations
{
    public class ValidationResult
    {
        public bool Status { get; set; }
        public List<string>? Errors { get; set; }

        public static ValidationResult GetDefaultResult() 
            => new ValidationResult { Errors = new List<string>(), Status = true };
    }
}
