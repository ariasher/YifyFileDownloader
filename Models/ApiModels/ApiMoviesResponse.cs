using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyFileDownloader.Models.ApiModels;

public class ApiMoviesResponse : BaseResponse
{
    public ApiMovieSummary? data { get; set; }
}
