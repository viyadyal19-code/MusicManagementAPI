using AppManagement.Api.Controllers;
using AppManagement.Infrastructure.Identity.DbContext;
using AppManagement.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Application.UnitTest
{
    public class SearchControllerTests
    {
        private readonly ApplicationIdentityDbContext _context;

        public SearchControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationIdentityDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            _context = new ApplicationIdentityDbContext(options);
        }

        public async Task Search_ShouldReturnResults()
        {
            var controller = new SearchController(_context);

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

            _context.Songs.Add(new Song
            {
                Title = "Test Song",
                Duration = 250
            });

            _context.SaveChanges();

            var result = await controller.Search("Test");

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Search_ShouldReturnBadRequest_KeywordIsEmpty()
        {
            var controller = new SearchController(_context);

            var result = await controller.Search("");

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

