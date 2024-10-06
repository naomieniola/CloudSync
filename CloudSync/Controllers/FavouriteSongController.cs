using CloudSync.Data;
using CloudSync.Models;
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
    public async Task<IActionResult> AddToFavourites(int songId, int artistId)
    {
        // Retrieve the ID of the logged-in user
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized(); // Ensure user is authenticated
        }

        try
        {
            // Check if the song is already in the user's favourites
            var existingFavourite = await _context.FavouriteSongs
                .FirstOrDefaultAsync(f => f.SongId == songId && f.UserId == userId);

            // If the song is not already a favourite, add it
            if (existingFavourite == null)
            {
                var favourite = new FavouriteSong
                {
                    SongId = songId,
                    UserId = userId
                };

                _context.FavouriteSongs.Add(favourite);
                await _context.SaveChangesAsync();
            }

            // Redirect back to the artist's song list after adding to favourites
            return RedirectToAction("SongsByArtist", "Artists", new { artistId = artistId });
        }
        catch (Exception ex)
        {
            // Log the error (optional) and return an error response or view
            Console.WriteLine($"Error adding song to favourites: {ex.Message}");
            return BadRequest("Error adding song to favourites.");
        }
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        // Retrieve the ID of the logged-in user
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized(); // Ensure user is authenticated
        }

        try
        {
            // Retrieve all favourite songs for the logged-in user
            var favouriteSongs = await _context.FavouriteSongs
                .Include(f => f.Song)
                .ThenInclude(s => s.Artist)
                .Where(f => f.UserId == userId)
                .ToListAsync();

            // Pass the favourite songs list to the Index view
            return View(favouriteSongs);
        }
        catch (Exception ex)
        {
            // Log the error (optional) and return an error response or view
            Console.WriteLine($"Error retrieving favourite songs: {ex.Message}");
            return BadRequest("Error retrieving favourite songs.");
        }
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RemoveFromFavourites(int songId)
    {
        // Retrieve the logged-in user's ID
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return Unauthorized();
        }

        // Fetch the favourite song, including the Song navigation property
        var favourite = await _context.FavouriteSongs
                              .Include(f => f.Song)
                              .ThenInclude(s => s.Artist) // Ensure the Artist is also included
                              .FirstOrDefaultAsync(f => f.SongId == songId && f.UserId == userId);

        if (favourite == null)
        {
            return NotFound(); // If the favourite song does not exist
        }

        // Remove the favourite song
        _context.FavouriteSongs.Remove(favourite);
        await _context.SaveChangesAsync();

        // Redirect back to the artist's song list
        return RedirectToAction("SongsByArtist", "Artists", new { artistId = favourite.Song.ArtistId });
    }


}
