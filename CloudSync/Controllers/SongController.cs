using Microsoft.AspNetCore.Mvc;
using CloudSync.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class SongsController : Controller
{
    private readonly ApplicationDbContext _context;

    public SongsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Fetch all songs from the database, including the related Artist entity
        var songs = _context.Songs.Include(s => s.Artist).ToList();
        return View(songs); // Pass the list of songs to the view
    }

}

