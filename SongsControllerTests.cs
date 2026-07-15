using System;
using Xunit;

public class SongControllerTests
{
    [Fact]
    public async Task GetSongs_ShouldReturnList()
    {
        var controller = new SongsController(_context);

        var result = await controller.GetSongs();

        Assert.NotNull(result);
    }

    [Fact]
    public async Task CreateSongs_ShouldAddSong()
    {
        var controller = new SongsController(_context);

        var newSong = new Song
        {
            Title = "Test Song",
            Duration = 276,
            ArtistId = 7,
            AlbumId = 6
        };

        var result = await controller.GetSongs();

        Assert.NotNull(result);
        
        var songs = _context.Songs.ToList();
        Assert.Contains(songs, songs => songs.Title == "Test Song");
    }
}
