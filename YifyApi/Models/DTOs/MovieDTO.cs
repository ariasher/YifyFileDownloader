namespace YifyApi.Models.DTOs
{
    public class MovieDTO
    {
        public long Id { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string EnglishTitle { get; set; }

        public string ImdbCode { get; set; }

        public int Year { get; set; }

        public double Rating { get; set; }

        public int Runtime { get; set; }

        public string? Genres { get; set; }

        public string Language { get; set; }
    }

    public class MovieWithTorrentDTO : MovieDTO
    {
        public List<TorrentDTO> Torrents { get; set; }
    }
}
