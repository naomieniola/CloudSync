namespace CloudSync.Models
{
    public class GenreArtists
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
    }
}
