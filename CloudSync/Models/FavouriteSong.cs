namespace CloudSync.Models
{
    public class FavouriteSong
    {
        public int FavouriteSongId { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }  // nav property for Song

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }  // nav property for User
    }
}