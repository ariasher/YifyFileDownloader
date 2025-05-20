using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyFileDownloader.Models.ApiModels
{
    public class ApiMovieTorrent
    {
        public string url { get; set; }
        public string hash { get; set; }
        public string quality { get; set; }
        public string type { get; set; }
    }
}
