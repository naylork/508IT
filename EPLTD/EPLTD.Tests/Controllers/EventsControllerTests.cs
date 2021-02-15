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
    public class EventControllerTests
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
                databaseContext.Event.AddRange(events());
                databaseContext.Customer.AddRange(customers());
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        private List<Event> events()
        {
            return new List<Event>
        {
          new Event{ EventID = 2, EventName="Underground Sound", EventDescription="Bring your friends and start to feel the underground sound", EventType="Urban", Start_Date=DateTime.Parse("20-09-2021"), End_Date=DateTime.Parse("27-09-2021")},
          new Event{ EventID = 3, EventName="Uptop Pop", EventDescription="Welcome to the pop uptop, get your dance on", EventType="Pop", Start_Date=DateTime.Parse("20-09-2021"), End_Date=DateTime.Parse("27-09-2021")},
               };
        }
        private List<Customer> customers()
        {
            return new List<Customer>
      {
          new Customer { EventID= events().Single( s => s.EventName == "Underground Sound").EventID, CustomerID = 2, FirstName = "Sandra",   LastName = "Tolisa", ContactEmail="sandatme@gmail.com", ContactNumber=int.Parse("123456789")},
          new Customer { EventID= events().Single( s => s.EventName == "Underground Sound").EventID, CustomerID = 3, FirstName = "Harry", LastName = "Mornrow", ContactEmail="harratme@gmail.com", ContactNumber=int.Parse("123456789")}
             };
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfEvents()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var eventController = new EventsController(dbContext);
            //Act
            var result = await eventController.Index_default();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Event>>(
              viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Details_ReturnsViewResultWithEventModel()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var eventController = new EventsController(dbContext);

            //Act
            var result = await eventController.Details(2);
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Event>(
            viewResult.ViewData.Model);
            Assert.Equal("Underground Sound", model.EventName);
            Assert.Equal(2, model.EventID);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public async Task Edit_ReturnsHttpNotFoundWhenEventIdNotFound(int eventId)
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var eventController = new EventsController(dbContext);
            //Act
            var result = await eventController.Edit(eventId);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }



    }
}
