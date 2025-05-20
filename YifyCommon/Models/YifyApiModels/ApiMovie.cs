namespace YifyCommon.Models.YifyApiModels
{
    public class ApiMovie
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string title_english { get; set; }
        public string title_long { get; set; }
        public string slug { get; set; }
        public string imdb_code { get; set; }
        public int year { get; set; }
        public double rating { get; set; }
        public int runtime { get; set; }
        public List<string> genres { get; set; }
        public string language { get; set; }
        public List<ApiMovieTorrent> torrents { get; set; }
    }
}
