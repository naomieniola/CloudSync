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
        // get all songs from db
        var songs = _context.Songs.Include(s => s.Artist).ToList();
        return View(songs);
    }

}

