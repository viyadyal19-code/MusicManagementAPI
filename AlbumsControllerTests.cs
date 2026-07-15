using System;
using Xunit;

public class AlbumsControllerTests
{
    private readonly ApplicationIdentityDbContext _context;

    [Fact]
    public async Task GetAlbums_ShouldReturnList()
    {

        var controller = new AlbumsController(_context);

        var result = await controller.GetAlbums();

        Assert.NotNull(result);
    }
}

[Fact]
public async Task CreateAlbum_ShouldAddAlbum()
{
    
    var controller = new AlbumsController(_context);

    var newAlbum = new Album
    {
        Title = "Test Album",
        ArtistId = 8   
    };

    
    var result = await controller.CreateAlbum(newAlbum);

    
    Assert.NotNull(result);

    var albums = _context.Albums.ToList();
    Assert.Contains(albums, a => a.Title == "Test Album");
}
