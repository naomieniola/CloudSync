using Humanizer;
using X.PagedList;

namespace CloudSync.Models
{
    public class ArtistsSongs
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IPagedList<Song> Songs { get; set; } // Use IPagedList here
        public string ArtistImage { get; set; }
        public string Biography { get; set; }
        public IPagedList<FavouriteSong> FavouriteSongs { get; set; } // Paginated Favourite Songs
    }
}
