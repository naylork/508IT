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
    public class AssetsNeededControllerTests
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
                databaseContext.AssetsNeeded.AddRange(assetsNeeded());
                databaseContext.Performance.AddRange(performance());
                databaseContext.Equipment.AddRange(equipment());
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        private List<AssetsNeeded> assetsNeeded()
        {
            return new List<AssetsNeeded>
        {
          new AssetsNeeded{ AssetsNeededID = 8, PerformanceID= performance().Single( s => s.PerformanceName == "Tom Jones").PerformanceID, EquipmentID = equipment().Single( s => s.Equipment_Name == "Toshiba Speakers").EquipmentID, EstimatedCosts = int.Parse("700"), ActualCosts = int.Parse("650"), AmountNeeded =int.Parse("22") },
          new AssetsNeeded{ AssetsNeededID = 9, PerformanceID= performance().Single( s => s.PerformanceName == "Rita Ora").PerformanceID, EquipmentID = equipment().Single( s => s.Equipment_Name == "Rockstar Guitar").EquipmentID, EstimatedCosts = int.Parse("300"), ActualCosts = int.Parse("400"), AmountNeeded = int.Parse("5") },
               };
        }
        private List<Performance> performance()
        {
            return new List<Performance>
      {
          new Performance { PerformanceID= 6, PerformanceName="Tom Jones", TimeSlotStart = DateTime.Parse("21:00"), TimeSlotEnd = DateTime.Parse("23:00")},
          new Performance { PerformanceID= 7, PerformanceName ="Rita Ora" , TimeSlotStart = DateTime.Parse("19:00"), TimeSlotEnd = DateTime.Parse("20:30")},
             };
        }

        private List<Equipment> equipment()
        {
            return new List<Equipment>
      {
          new Equipment { EquipmentID=4, Equipment_Name = "Toshiba Speakers", Availability = int.Parse("1000")},
          new Equipment { EquipmentID=5, Equipment_Name = "Rockstar Guitar", Availability = int.Parse("500")},
             };
        }


        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfAssetsNeeded()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var AssetsNeededController = new AssetsNeededsController(dbContext);
            //Act
            var result = await AssetsNeededController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AssetsNeeded>>(
              viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Details_ReturnsViewResultWithAssetsNeededModel()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var AssetsNeededController = new AssetsNeededsController(dbContext);

            //Act
            var result = await AssetsNeededController.Details(9);
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<AssetsNeeded>(
            viewResult.ViewData.Model);
            Assert.Equal(int.Parse("7"), model.PerformanceID);
            Assert.Equal(9, model.AssetsNeededID);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public async Task Edit_ReturnsHttpNotFoundWhenAssetsNeededIdNotFound(int assetsNeededID)
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var AssetsNeededController = new AssetsNeededsController(dbContext);
            //Act
            var result = await AssetsNeededController.Edit(assetsNeededID);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }



    }
}
