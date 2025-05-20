namespace YifyCommon.Models.YifyApiModels;

public abstract class BaseResponse
{
    // Either ok or error
    public string status { get; set; }

    // Either error message or succesful message
    public string status_message { get; set; }
}
