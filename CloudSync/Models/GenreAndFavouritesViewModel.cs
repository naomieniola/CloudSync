using System.Collections.Generic;

namespace CloudSync.Models
{
    public class GenreAndFavouritesViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<FavouriteSong> FavouriteSongs { get; set; }
    }
}
