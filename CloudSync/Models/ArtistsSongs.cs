namespace CloudSync.Models
{
    public class ArtistsSongs
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public string ArtistImage { get; set; }
        public string Biography { get; set; }

    }
}
