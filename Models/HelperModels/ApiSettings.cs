using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YifyFileDownloader.Models.HelperModels;

public class ApiSettings
{
    public int MinimumYear { get; set; }
    public int Limit { get; set; }
    public List<string> Qualities { get; set; }
    public double MinimumRating { get; set; }
    public List<string> Genres { get; set; }
    public string Endpoint { get; set; }

    public string QualitiesStringify
    {
        get
        {
            if (Qualities == null || Qualities.Count == 0)
                return string.Empty;

            return string.Join(",", Qualities);
        }
    }

    public string GenresStringify
    {
        get
        {
            if (Genres == null || Genres.Count == 0)
                return string.Empty;

            return string.Join(",", Genres);
        }
    }
}
