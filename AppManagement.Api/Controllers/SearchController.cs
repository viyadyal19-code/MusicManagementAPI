using AppManagement.Infrastructure.Identity.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly ApplicationIdentityDbContext _context;

    public SearchController(ApplicationIdentityDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Search(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return BadRequest("Keyword is required");

        keyword = keyword.ToLower();

        
        var songs = await _context.Songs
            .Where(s => s.Title.ToLower().Contains(keyword))
            .Select(s => new { s.Id, s.Title })
            .ToListAsync();

        
        var albums = await _context.Albums
            .Where(a => a.Title.ToLower().Contains(keyword))
            .Select(a => new { a.Id, a.Title })
            .ToListAsync();

        
        var artists = await _context.Artists
            .Where(a =>
                a.FirstName.ToLower().Contains(keyword) ||
                a.LastName.ToLower().Contains(keyword))
            .Select(a => new
            {
                a.Id,
                Name = a.FirstName + " " + a.LastName
            })
            .ToListAsync();


        return Ok(new
        {
            Songs = songs,
            Albums = albums,
            Artists = artists
        });
    }

}



