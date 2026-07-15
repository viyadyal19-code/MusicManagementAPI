using AppManagement.Application.Abstractions.Services;
using AppManagement.Application.DTOs.Song;
using Microsoft.AspNetCore.Mvc;

namespace AppManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly ISongService _songService;

    public SongsController(ISongService SongService)
    {
        _songService = SongService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSongs()
    {
        return Ok(await _songService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddSong(SongRequest request)
    {
        var song = await _songService.CreateAsync(request);
        return Ok(song);
    }


    //Search by title OR artist
    [HttpGet("search")]
    public async Task<IActionResult> SearchSongs(string keyword)
    {
        var songs = await _songService.SearchAsync(keyword);

        return Ok(songs);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSong(int id, SongRequest request)
    {
        var song = await _songService.UpdateAsync(id, request);
        return Ok(song);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSong(int id)
    {
        var deleted = await _songService.DeleteAsync(id);

        return deleted
            ? Ok("Song deleted successfully")
            : NotFound("Song not found");
    }
}