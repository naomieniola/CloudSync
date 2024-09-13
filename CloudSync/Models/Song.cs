using CloudSync.Models;

namespace CloudSync.Models
{
    public class Song
    {
        public int SongId { get; set; }
    public string SongName { get; set; }
    public TimeSpan SongDuration { get; set; }
    public string SongFile { get; set; }

    // New field
    public string SongImage { get; set; } 

    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
    }
