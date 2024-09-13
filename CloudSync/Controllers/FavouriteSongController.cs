using CloudSync.Data;
using CloudSync.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

public class FavouriteSongsController : Controller
{
    private readonly ApplicationDbContext _context;

    public FavouriteSongsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddToFavourites(int songId, int artistId) // needed to link artist to song
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // check if song is already in the user's favourites
        var existingFavourite = await _context.FavouriteSongs
            .FirstOrDefaultAsync(f => f.SongId == songId && f.UserId == userId);

        if (existingFavourite == null)
        {
            // add song to the user's favourites
            var favourite = new FavouriteSong
            {
                SongId = songId,
                UserId = userId
            };
            _context.FavouriteSongs.Add(favourite);
            await _context.SaveChangesAsync();
        }

        // redirect back to artist's song list
        return RedirectToAction("SongsByArtist", "Artists", new { artistId = artistId });
    }
}