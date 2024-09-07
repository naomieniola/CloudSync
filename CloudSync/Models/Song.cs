namespace CloudSync.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public TimeSpan SongDuration { get; set; }
        public string SongFile { get; set; }

        // fk's
        public int ArtistId { get; set; }
        public int GenreId { get; set; }

        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
        public ICollection<FavouriteSong> FavouriteSongs { get; set; }
    }

}
