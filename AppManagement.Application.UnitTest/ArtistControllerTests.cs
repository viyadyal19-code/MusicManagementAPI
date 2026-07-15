using AppManagement.Api.Controllers;
using AppManagement.Infrastructure.Identity.DbContext;
using AppManagement.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.UnitTest
{
    public class ArtistControllerTests
    {
        private readonly ApplicationIdentityDbContext _context;

        public ArtistControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationIdentityDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            _context = new ApplicationIdentityDbContext(options);
        }

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
            var controller = new ArtistController(_context);

            var newArtist = new Artist
            {
                FirstName = "Test",
                LastName = "Artist",
                Country = "Mauritius"
            };

            var result = await controller.AddArtist(newArtist);

            Assert.NotNull(result);

            var artist = _context.Artists.ToList();
            Assert.Contains(artist, a => a.FirstName == "Test");
        }

        [Fact]
        public async Task UpdateArtist_ShouldModifyArtist()
        {
            var controller = new ArtistController(_context);

            var artist = new Artist
            {
                FirstName = "Bob ",
                LastName = "Marley",
                Country = "Jamaica"
            };

            await controller.AddArtist(artist);

            var updatedArtist = new Artist
            {
                FirstName = "Updated ",
                LastName = "Artist",
                Country = "Jamaica"
            };

            var result = await controller.UpdateArtist(1, updatedArtist);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteArtist_ShouldRemoveArtist()
        {
            var controller = new ArtistController(_context);

            var artist = new Artist
            {
                FirstName = "Viya ",
                LastName = "Dyal",
                Country = "Mauritius"
            };

            await controller.AddArtist(artist);

            var result = await controller.DeleteArtist(1);

            Assert.NotNull(result);
        }
    }
}
