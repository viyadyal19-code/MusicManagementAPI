using AppManagement.Infrastructure.Identity.DbContext;
using AppManagement.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistController : ControllerBase
{
    private readonly ApplicationIdentityDbContext _context;

    public ArtistController(ApplicationIdentityDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetArtists()
    {
        return Ok(await _context.Artists.ToListAsync());
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchArtist(string keyword)
    {
        var artists = await _context.Artists
            .Include(a => a.Songs)
            .Where(a =>
                a.Id.ToString() == keyword || 
                a.FirstName.ToLower().Contains(keyword.ToLower()) || 
                a.LastName.ToLower().Contains(keyword.ToLower())      
            )
            .ToListAsync();

        if (!artists.Any())
            return NotFound("Artist not found");

        var songs = artists.SelectMany(a => a.Songs).ToList();

        return Ok(songs);
    }

    [HttpPost]
    public async Task<IActionResult> AddArtist(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
        return Ok(artist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArtist(int id, Artist updatedArtist)
    {
        var artist = await _context.Artists.FindAsync(id);

        if (artist is null)
            return NotFound("Artist not found");

        artist.FirstName = updatedArtist.FirstName;
        artist.LastName = updatedArtist.LastName;
        artist.Country = updatedArtist.Country;

        await _context.SaveChangesAsync();

        return Ok(artist);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtist(int id)
    {
        var artist = await _context.Artists
            .Include(a => a.Songs)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (artist is null)
            return NotFound("Artist not found");

        if (artist.Songs.Any())
            return BadRequest("Cannot delete artist with existing songs");

        _context.Artists.Remove(artist);
        await _context.SaveChangesAsync();

        return Ok("Artist deleted");
    }
}