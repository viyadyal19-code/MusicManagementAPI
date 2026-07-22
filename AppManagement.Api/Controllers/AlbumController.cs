using AppManagement.Application.Abstractions.Services;
using AppManagement.Application.DTOs.Album;
using AppManagement.Application.Model;
using AppManagement.Infrastructure.Identity.DbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppManagement.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService Albumservice)
    {
        _albumService = Albumservice;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlbums()
    {
        return Ok(await _albumService.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Addalbum(AlbumRequest request)
    {
        var album = await _albumService.CreateAsync(request); ;
        return Ok(album);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Updatealbum(int id, AlbumRequest request)
    {
        var album = await _albumService.UpdateAsync(id, request);
        return Ok(album);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletealbum(int id)
    {
        return await _albumService.DeleteAsync(id)
         ? Ok("album deleted")
         : BadRequest();
    }
}