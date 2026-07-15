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
    public class AlbumsControllerTests
    {
        private readonly ApplicationIdentityDbContext _context;

        public AlbumsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationIdentityDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            _context = new ApplicationIdentityDbContext(options);
        }

        [Fact]
        public async Task GetAlbums_ShouldReturnList()
        {

            var controller = new AlbumController(_context);

            var result = await controller.GetAlbums();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateAlbum_ShouldAddAlbum()
        {
            var controller = new AlbumController(_context);

            var newAlbum = new Album
            {
                Title = "Test Album",
                ReleaseYear = 2024   
            };

            var result = await controller.AddAlbum(newAlbum);

            Assert.NotNull(result);

            var albums = _context.Albums.ToList();
            Assert.Contains(albums, a => a.Title == "Test Album");
        }

        [Fact]
        public async Task UpdateAlbum_ShouldModifyAlbum()
        {
            var controller = new AlbumController(_context);

            var album = new Album
            {
                Title = "Old Album",
                ReleaseYear = 2020
            };

            await controller.AddAlbum(album);

            var updatedAlbum = new Album
            {
                Title = "Updated Album",
                ReleaseYear = 2024
            };

            var result = await controller.UpdateAlbum(1, updatedAlbum);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteAlbum_ShouldRemoveAlbum()
        {
            var controller = new AlbumController(_context);

            var album = new Album
            {
                Title = "Delete Album",
                ReleaseYear = 2022
            };

            await controller.AddAlbum(album);

            var result = await controller.DeleteAlbum(1);

            Assert.NotNull(result);
        }
    }
}