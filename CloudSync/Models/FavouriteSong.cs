using CloudSync.Models;

public class FavouriteSong
{
    public int FavouriteSongId { get; set; }
    public int SongId { get; set; }

    // Foreign key for User
    public string UserId { get; set; } // Match this type with IdentityUser's key (string)

    // Navigation property
    public User User { get; set; }

    // Navigation for Song
    public Song Song { get; set; }
}
