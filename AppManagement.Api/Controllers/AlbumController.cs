using AppManagement.Infrastructure.Identity.DbContext;
using AppManagement.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : ControllerBase
{
    private readonly ApplicationIdentityDbContext _context;

    public AlbumController(ApplicationIdentityDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlbums()
    {
        return Ok(await _context.Albums.ToListAsync()); 
    }

    [HttpPost]
    public async Task<IActionResult> AddAlbum(Album album)
    {
        _context.Albums.Add(album);  
        await _context.SaveChangesAsync();
        return Ok(album);
    }

    [HttpGet("{id}/songs")]
    public async Task<IActionResult> GetSongsByAlbum(int id)
    {
        var songs = await _context.Songs
            .Where(s => s.AlbumId == id)
            .ToListAsync();

        return Ok(songs);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAlbum(int id, Album updatedAlbum)
    {
        var album = await _context.Albums.FindAsync(id);

        if (album is null)
            return NotFound("Album not found");

        album.Title = updatedAlbum.Title;
        album.ReleaseYear = updatedAlbum.ReleaseYear;

        await _context.SaveChangesAsync();

        return Ok(album);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        var album = await _context.Albums
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (album is null)
            return NotFound("Album not found");

        if (album.Songs.Any())
            return BadRequest("Cannot delete album with existing songs");

        _context.Albums.Remove(album);
        await _context.SaveChangesAsync();

        return Ok("Album deleted");
    }
}