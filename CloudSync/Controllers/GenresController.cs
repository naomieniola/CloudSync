using CloudSync.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CloudSync.Models;


public class GenresController : Controller
{
    private readonly ApplicationDbContext _context;

    public GenresController(ApplicationDbContext context)
    {
        _context = context;
    }

    // This action fetches all genres
    public IActionResult Index()
    {
        var genres = _context.Genres.ToList();
        return View(genres); // Pass the list of genres to the Index view
    }

    // This action fetches all artists in a specific genre
    public IActionResult ArtistsByGenre(int genreId)
    {
        var genre = _context.Genres
            .Include(g => g.Artists)
            .FirstOrDefault(g => g.GenreId == genreId);

        if (genre == null) return NotFound();

        var viewModel = new GenreArtists
        {
            GenreId = genre.GenreId,
            GenreName = genre.GenreName,
            Artists = genre.Artists
        };

        return View(viewModel);
    }
}
