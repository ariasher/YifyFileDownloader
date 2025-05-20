namespace YifyFileDownloader.Models.YifyApiModels
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
