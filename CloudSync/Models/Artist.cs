using CloudSync.Models;

namespace CloudSync.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public int GenreId { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; } 
        public Genre Genre { get; set; }
        public ICollection<Song> Songs { get; set; }
    }

}

