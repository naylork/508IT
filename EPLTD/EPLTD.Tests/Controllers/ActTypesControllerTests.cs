using EPLTD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EPLTD.Models;
using EPLTD.Controllers;

namespace EPLTD.Tests.Controllers
{
    public class ActTypeControllerTests
    {
        private async Task<ApplicationDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Users.CountAsync() <= 0)
            {
                databaseContext.ActType.AddRange(actType());
                databaseContext.Performers.AddRange(performers());
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        private List<ActType> actType()
        {
            return new List<ActType>
        {
          new ActType{ GenreID = 8, Genre="Urban"},
          new ActType{ GenreID = 9, Genre="Funk"},
               };
        }
        private List<Performers> performers()
        {
            return new List<Performers>
      {
          new Performers { GenreID= actType().Single( s => s.Genre == "Urban").GenreID, PerformersID = 2, FullName = "Pop Smoke", ContactEmail="christiandiordior@gmail.com", ContactNumber=int.Parse("123456789"),},
          new Performers { GenreID= actType().Single( s => s.Genre == "Funk").GenreID, PerformersID = 3, FullName = "Snoop Dogg", ContactEmail="deeohdoubleg@gmail.com", ContactNumber=int.Parse("123456789")}
             };
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfActTypes()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var ActTypeController = new ActTypesController(dbContext);
            //Act
            var result = await ActTypeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ActType>>(
              viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Details_ReturnsViewResultWithActTypeModel()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var ActTypeController = new ActTypesController(dbContext);

            //Act
            var result = await ActTypeController.Details(9);
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ActType>(
            viewResult.ViewData.Model);
            Assert.Equal("Funk", model.Genre);
            Assert.Equal(9, model.GenreID);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public async Task Edit_ReturnsHttpNotFoundWhenActTypeIdNotFound(int genreId)
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var ActTypeController = new ActTypesController(dbContext);
            //Act
            var result = await ActTypeController.Edit(genreId);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }



    }
}
