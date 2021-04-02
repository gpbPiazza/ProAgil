using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProAgil.API.Controllers;
using ProAgil.Domain;
using ProAgil.Repository;
using Xunit;
namespace ProAgil.Tests
{
	public class EventControllerTest
	{
		private readonly Mock<IProAgilRepository> repositoryMock = new Mock<IProAgilRepository>();
		private readonly EventController controllerToBeTested;
		public EventControllerTest()
		{
			this.controllerToBeTested = new EventController(this.repositoryMock.Object);
		}
		[Fact]
		public async Task GetAllEvents_Should_ReturnOkResult()
		{
			//Arrange 
			//Act
			var result = await this.controllerToBeTested.Get();
			//Assert
			Assert.IsType<OkObjectResult>(result);
		}

		[Fact]
		public async Task GetAllEvents_Should_ReturnArrayOfEvents()
		{
			//Arrange 
			Event[] eventsMock = {
				new Event() {
					Place = "Rio de Janeiro",
					EventDate = new DateTime(),
					Theme = ".NET core",
					PeopleAmount = 230,
					ImageUrl = "img3.jpg",
					PhoneNumber = "97845655",
					Email =  "dotnetCore@dotnetCore.com.br",
				},
				new Event() {
					Place = "Mock Janeiro",
					EventDate = new DateTime(),
					Theme = "Mock .NET core",
					PeopleAmount = 230,
					ImageUrl = "Mockimg3.jpg",
					PhoneNumber = "97845655",
					Email =  "MockdotnetCore@dotnetCore.com.br",
				}
			};

			this.repositoryMock.Setup(repo => repo.GetAllEventAsync(true))
				.Returns(Task.FromResult(eventsMock));
			//Act
			var result = await this.controllerToBeTested.Get();
			
			//Assert
			var okResult =  Assert.IsType<OkObjectResult>(result);
			var responseValue = Assert.IsType<Event[]>(okResult.Value);
			Assert.Equal(2, responseValue.Length);
		}
		[Fact]
		public async Task GetEventById_Should_ReturnNotFoundResult()
		{
			//Arrange
			//Act
			var result = await this.controllerToBeTested.Get(1);

			//Assert	{Microsoft.AspNetCore.Mvc.NotFoundResult}
			Assert.IsType<NotFoundResult>(result);
		}
		
		[Fact]
		public async Task GetEventById_WithMockedEvent_Should_ReturOneEvent()
		{
			//Arrange
			int mockId = 2;
			Event eventMock = new Event()
			{
				Place = "Mock Janeiro",
				EventDate = new DateTime(),
				Theme = "Mock .NET core",
				PeopleAmount = 230,
				ImageUrl = "Mockimg3.jpg",
				PhoneNumber = "97845655",
				Email = "MockdotnetCore@dotnetCore.com.br",
			};
			this.repositoryMock.Setup(repo => repo.GetEventAsyncById(mockId, true))
				.ReturnsAsync(eventMock);
			//Act
			var result = await this.controllerToBeTested.Get(2);

			//Assert	
			var okResult = Assert.IsType<OkObjectResult>(result);
			var responseValue = Assert.IsType<Event>(okResult.Value);
			Assert.Equal(eventMock.PeopleAmount, responseValue.PeopleAmount);
		}

		[Fact]
		public async Task GetEventsByTheme_Should_ReturnZeroEvents()
        {
			//Arrange
			string eventThemeMocked = "Dont exist any Event";
			
			//Act
			var result = await this.controllerToBeTested.Get($"getByTheme/{eventThemeMocked}");

			//Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var valueResponse = Assert.IsType<Event[]>(okResult.Value);
			Assert.Empty(valueResponse);
		}

		[Fact]
		public async Task RegisterEvent_Should_ReturnNewEvent()
		{
			//Arrange
			Event eventMock = new Event()
			{
				Place = "Mock Janeiro",
				EventDate = new DateTime(),
				Theme = "Mock .NET core",
				PeopleAmount = 230,
				ImageUrl = "Mockimg3.jpg",
				PhoneNumber = "97845655",
				Email = "MockdotnetCore@dotnetCore.com.br",
			};
			this.repositoryMock.Setup(repo => repo.Add(new Event()))
				.Callback<Event>(arg => eventMock = arg);
			this.repositoryMock.Setup(repo => repo.SaveChangesAsync())
				.Returns(Task.FromResult(true));
			//Act
			var result = await this.controllerToBeTested.Post(eventMock);

			//Assert	
			var okResult = Assert.IsType<CreatedResult>(result);
			var responseValue = Assert.IsType<Event>(okResult.Value);
            Assert.Equal(eventMock.PeopleAmount, responseValue.PeopleAmount);
		}
		[Fact]
		public async Task RegisterEvent_Should_ReturnBadRequest()
		{
			//Arrange
			Event eventMock = new Event()
			{
				Place = "Mock Janeiro",
				EventDate = new DateTime(),
				Theme = "Mock .NET core",
				PeopleAmount = 230,
				ImageUrl = "Mockimg3.jpg",
				PhoneNumber = "97845655",
				Email = "MockdotnetCore@dotnetCore.com.br",
			};
			this.repositoryMock.Setup(repo => repo.Add(new Event()))
				.Callback<Event>(arg => eventMock = arg);
			this.repositoryMock.Setup(repo => repo.SaveChangesAsync())
				.Returns(Task.FromResult(false));
			//Act
			var result = await this.controllerToBeTested.Post(eventMock);

			//Assert {Microsoft.AspNetCore.Mvc.BadRequestResult}	
			var okResult = Assert.IsType<BadRequestResult>(result);
		}
		[Fact]
		public async Task UpdateEvent_Should_ReturnEventNotFound()
		{
			//Arrange
			int eventId = 2;
			Event eventMock = new Event()
			{
				Place = "Mock Janeiro",
				EventDate = new DateTime(),
				Theme = "Mock .NET core",
				PeopleAmount = 230,
				ImageUrl = "Mockimg3.jpg",
				PhoneNumber = "97845655",
				Email = "MockdotnetCore@dotnetCore.com.br",
			};
			this.repositoryMock.Setup(repo => repo.Update(new Event()))
				.Callback<Event>(arg => eventMock = arg);
			this.repositoryMock.Setup(repo => repo.SaveChangesAsync())
				.Returns(Task.FromResult(false));
			//Act
			var result = await this.controllerToBeTested.Put(eventId, eventMock);

			//Assert {Microsoft.AspNetCore.Mvc.BadRequestResult}	
			Assert.IsType<NotFoundResult>(result);
		}
	}
}



		