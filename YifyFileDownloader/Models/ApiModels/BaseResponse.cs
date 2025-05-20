using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyFileDownloader.Models.ApiModels;

public abstract class BaseResponse
{
    // Either ok or error
    public string status { get; set; }

    // Either error message or succesful message
    public string status_message { get; set; }
}
