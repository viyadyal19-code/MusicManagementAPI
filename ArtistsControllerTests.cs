using System;
using Xunit;

public class ArtistControllerTests
{
    [Fact]
    public async Task GetArtist_ShouldReturnList()
    {
        var controller = new ArtistController(_context);

        var result = await controller.GetArtists();

        Assert.NotNull(result);
    }

    [Fact]
    public async Task CreateArtist_ShouldAddArtist()
    {
        // Arrange
        var controller = new ArtistsController(_context);

        var newArtist = new Artist
        {
            FirstName = "xunitTest",
            LastName = "Artist"
        };

        // Act
        var result = await controller.CreateArtist(newArtist);

        // Assert
        Assert.NotNull(result);

        var artists = _context.Artists.ToList();
        Assert.Contains(artists, a => a.FirstName == "xunitTest" && a.LastName == "Artist");
    }

}
