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
			var test =  Assert.IsType<OkObjectResult>(result);
			var arrayEvents = Assert.IsType<Event[]>(test.Value);
			Assert.Equal(2, arrayEvents.Length);
		}
	}
}



		