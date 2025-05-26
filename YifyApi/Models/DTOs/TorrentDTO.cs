namespace YifyApi.Models.DTOs
{
    public class TorrentDTO
    {
        public long Id { get; set; }

        public bool? IsActive { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

        public string URL { get; set; }

        public string Hash { get; set; }

        public string Quality { get; set; }

        public string Type { get; set; }
    }
}
