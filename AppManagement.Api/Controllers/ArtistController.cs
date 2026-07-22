using AppManagement.Application.Abstractions.Services;
using AppManagement.Application.DTOs.Artist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppManagement.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ArtistController : ControllerBase
{
    private readonly IArtistService _artistService;

    public ArtistController(IArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetArtists()
    {
        return Ok(await _artistService.GetAllAsync());
    }

    [HttpGet("{id}/songs")]
    public async Task<IActionResult> GetArtistSongs(int id)
    {
        var songs = await _artistService.GetSongsByArtistAsync(id);

        return Ok(songs);
    }

    [HttpPost]
    public async Task<IActionResult> AddArtist(ArtistRequest request)
    {
        var artist = await _artistService.CreateAsync(request); ;
        return Ok(artist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArtist(int id, ArtistRequest request)
    {
        var artist = await _artistService.UpdateAsync(id, request);
        return Ok(artist);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtist(int id)
    {
        return await _artistService.DeleteAsync(id)
         ? Ok("Artist deleted")
         : BadRequest();
    }
}