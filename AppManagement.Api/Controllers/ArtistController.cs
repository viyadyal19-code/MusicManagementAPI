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

    [HttpPost]
    public async Task<IActionResult> AddArtist(Artist artist)
    {
        _context.Artists.Add(artist);
        await _context.SaveChangesAsync();
        return Ok(artist);
    }
}