namespace CloudSync.Models
{
    public class FavouriteSong
    {
        public int FavouriteSongId { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
