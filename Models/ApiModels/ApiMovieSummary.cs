using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyFileDownloader.Models.ApiModels
{
    public class ApiMovieSummary
    {
        public int movie_count { get; set; }
        public int limit { get; set; }
        public int page_number { get; set; }
        public List<ApiMovie> movies { get; set; }
        public string date_uploaded { get; set; }
        public long date_uploaded_unix { get; set; }
    }
}
