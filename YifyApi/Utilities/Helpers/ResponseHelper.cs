using YifyApi.Models.Constants;
using YifyApi.Models.Transit.Response;
using YifyCommon.Extensions;

namespace YifyApi.Utilities.Helpers
{
    public class ResponseHelper
    {
        public ResponseDTO GetSuccessResponse(string message = "OK", object? data = null)
        => new ResponseDTO
        {
            Message = message,
            Data = data,
            Status = ResponseStatus.Success.Name()
        };

        public ResponseDTO GetErrorResponse(string message, object? data = null)
        => new ResponseDTO
        {
            Message = message,
            Data = data,
            Status = ResponseStatus.Error.Name()
        };
    }
}
