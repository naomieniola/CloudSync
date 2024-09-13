using Microsoft.EntityFrameworkCore;
using CloudSync.Data;
using Microsoft.AspNetCore.Mvc;
using CloudSync.Models;


public class ArtistsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ArtistsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // This action fetches all songs by a specific artist
    public IActionResult SongsByArtist(int artistId, int genreId)
    {
        var artist = _context.Artists
            .Include(a => a.Songs)
            .FirstOrDefault(a => a.ArtistId == artistId);

        if (artist == null) return NotFound();

        var viewModel = new ArtistsSongs
        {
            ArtistId = artist.ArtistId,
            ArtistName = artist.ArtistName,
            Songs = artist.Songs,
            ArtistImage = artist.Image,
            Biography = artist.Biography
        };

        ViewBag.GenreId = genreId;  // go back to previous page

        return View(viewModel);

    }
}
