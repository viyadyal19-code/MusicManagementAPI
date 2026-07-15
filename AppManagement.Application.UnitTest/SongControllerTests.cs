using AppManagement.Api.Controllers;
using AppManagement.Infrastructure.Identity.DbContext;
using AppManagement.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.UnitTest
{
    public class SongControllerTests
    {
        private readonly ApplicationIdentityDbContext _context;

        public SongControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationIdentityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationIdentityDbContext(options);
        }

        [Fact]
        public async Task GetSongs_ShouldReturnList()
        {

            var controller = new SongsController(_context);

            var result = await controller.GetSongs();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateSong_ShouldAddSong()
        {
            var controller = new SongsController(_context);

            _context.Artists.Add(new Artist
            {
                FirstName = "Test",
                LastName = "Artist",
                Country = "MU"
            });

            _context.Albums.Add(new Album
            {
                Title = "Test Album",
                ReleaseYear = 2020
            });

            _context.SaveChanges();

            var newSong = new Song
            {
                Title = "Test Song",
                Duration = 250,
                ArtistId = 1,
                AlbumId = 1

            };

            var result = await controller.AddSong(newSong);

            Assert.NotNull(result);

            var songs = _context.Songs.ToList();
            Assert.Contains(songs, s => s.Title == "Test Song");
        }


        [Fact]
        public async Task UpdateSong_ShouldModifySong()
        {
            var controller = new SongsController(_context);

            var song = new Song
            {
                Title = "Old Song",
                Duration = 250,
                ArtistId = 7,
                AlbumId = 6
            };

            await controller.AddSong(song);

            var updatedSong = new Song
            {
                Title = "Updated Song",
                Duration = 250,
                ArtistId = 7,
                AlbumId = 6
            };

            var result = await controller.UpdateSong(1, updatedSong);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteSong_ShouldRemoveSong()
        {
            var controller = new SongsController(_context);

            var song = new Song
            {
                Title = "Delete Song",
                Duration = 250,
                ArtistId = 7,
                AlbumId = 6
            };

            await controller.AddSong(song);

            var result = await controller.DeleteSong(1);

            Assert.NotNull(result);
        }
    }
}
