using AppManagement.Infrastructure.Identity.DbContext;
using AppManagement.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly ApplicationIdentityDbContext _context;

    public SongsController(ApplicationIdentityDbContext context)
    {
        _context = context;
    }

    // GET all songs
    [HttpGet]
    public async Task<IActionResult> GetSongs()
    {
        var songs = await _context.Songs
            .Include(s => s.Artist)
            .Include(s => s.Album)
            .ToListAsync();


        return Ok(songs);
    }

    // POST new song
    [HttpPost]
    public async Task<IActionResult> AddSong(Song song)
    {
        // Check if Artist already exists
        var artist = await _context.Artists.FindAsync(song.ArtistId);
        if (artist == null)
        {
            return BadRequest("Artist not found");
        }

        // Check if Album already exists 
        if (song.AlbumId != null)
        {
            var album = await _context.Albums.FindAsync(song.AlbumId);
            if (album == null)
            {
                return BadRequest("Album not found");
            }
        }

        _context.Songs.Add(song);
        await _context.SaveChangesAsync();

        return Ok(song);
    }

    //Search by title OR artist
    [HttpGet("search")]
    public async Task<IActionResult> SearchSongs(string keyword)
    {
        var songs = await _context.Songs
            .Include(s => s.Artist)
            .Include(s => s.Album)
            .Where(s => 
                s.Title.Contains(keyword) ||
                (s.Artist != null &&
                (s.Artist.FirstName.Contains(keyword) || 
                s.Artist.LastName.Contains(keyword)))
                )
            .ToListAsync();

        return Ok(songs);
    }

}