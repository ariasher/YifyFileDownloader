using YifyApi.Models.Transit.Request;
using YifyApi.Models.Validations;
using YifyApi.Validations.Contracts;

namespace YifyApi.Validations
{
    public class ValidateBaseRequestDto : IValidate<BaseRequestDTO>
    {
        private const int MIN_LIMIT = 1;
        private const int MAX_LIMIT = 100;
        private const int MIN_PAGE = 1;
        private const int MAX_PAGE = int.MaxValue;
        private readonly string LIMIT_MESSAGE = $"Limit should be in range {MIN_LIMIT} and {MAX_LIMIT}.";
        private readonly string PAGE_MESSAGE = $"Page should be in range {MIN_PAGE} and {MAX_PAGE}.";

        public virtual ValidationResult Validate(BaseRequestDTO request)
        {
            var result = ValidationResult.GetDefaultResult();

            if (request.Limit < MIN_LIMIT || request.Limit > MAX_LIMIT)
            {
                result.Errors.Add(LIMIT_MESSAGE);
                result.Status = false;
            }

            if (request.Page < MIN_PAGE || request.Page > MAX_PAGE)
            {
                result.Errors.Add(PAGE_MESSAGE);
                result.Status = false;
            }

            return result;
        }
    }
}
