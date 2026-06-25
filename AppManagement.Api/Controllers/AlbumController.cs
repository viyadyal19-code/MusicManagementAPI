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
}