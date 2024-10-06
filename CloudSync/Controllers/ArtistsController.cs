using Microsoft.EntityFrameworkCore;
using CloudSync.Data;
using Microsoft.AspNetCore.Mvc;
using CloudSync.Models;
using System.Security.Claims;
using X.PagedList;

public class ArtistsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ArtistsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Gets all songs by a specific artist along with the favourite songs of the logged-in user

    public IActionResult SongsByArtist(int artistId, int genreId, int pageNumber = 1, int favPageNumber = 1, int pageSize = 4, int favPageSize = 4)
    {
        var artist = _context.Artists
            .Include(a => a.Songs)
            .FirstOrDefault(a => a.ArtistId == artistId);

        if (artist == null) return NotFound();

        // Get paginated list of songs
        var paginatedSongs = artist.Songs.ToPagedList(pageNumber, pageSize);

        // Get user ID
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // Get paginated list of favorite songs
        var paginatedFavourites = _context.FavouriteSongs
            .Where(f => f.UserId == userId)
            .Include(f => f.Song)
            .ThenInclude(s => s.Artist)
            .ToPagedList(favPageNumber, favPageSize);

        // Construct view model
        var viewModel = new ArtistsSongs
        {
            ArtistId = artist.ArtistId,
            ArtistName = artist.ArtistName,
            Songs = paginatedSongs, // Assign paginated songs
            ArtistImage = artist.Image,
            Biography = artist.Biography,
            FavouriteSongs = paginatedFavourites // Assign paginated favourite songs
        };

        ViewBag.GenreId = genreId;
        ViewBag.CurrentPage = pageNumber; // For songs pagination
        ViewBag.CurrentFavouritePage = favPageNumber; // For favourites pagination
        ViewBag.PreviousUrl = Request.GetTypedHeaders().Referer?.ToString();

        return View(viewModel);
    }

}

