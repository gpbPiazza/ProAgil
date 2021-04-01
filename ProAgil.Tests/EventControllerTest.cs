using Xunit;
using System;

namespace ProAgil.Tests.UnitTests

{
	public class EventControllerTest
	{
		private readonly IProAgilRepository mockRepository;
		private readonly EventController controller;

		public EventControllerTest()
		{
			this.mockRepository = new ProAgilRepositoryFake();
			this.controller = new EventController(this.mockRepository);
		}
		[Fact]
		public void Get_All_Events_ReturnOkResult()
		{
			//Act
			var okResult = this.controller.Get();

			//Assert
			Assert.IsType<OkObjectResult>(okResult.Result);
		}
	}
}