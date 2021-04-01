using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProAgil.Repository.Data;
using ProAgil.Domain;

namespace ProAgil.API.Controllers
{
	[ApiController]
	[Route("/api/v1")]
	public class ValuesController : ControllerBase
	{
		public readonly ProAgilContext Context;
		public ValuesController(ProAgilContext context)
				{
					this.Context = context;
				}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var events = await this.Context.Events.ToListAsync();
				return Ok(events);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Event>> Get(int id)
		{
			return  await this.Context.Events.FirstOrDefaultAsync(element => element.Id == id);
		}
	}
}









// using Xunit;
// using System;
// using ProAgil.Repository;

// namespace ProAgil.Tests.UnitTests

// {
// 	public class EventControllerTest
// 	{
// 		private readonly IProAgilRepository mockRepository;
// 		private readonly EventController controller;

// 		public EventControllerTest()
// 		{
// 			this.mockRepository = new ProAgilRepositoryFake();
// 			this.controller = new EventController(this.mockRepository);
// 		}

// 		[Fact]
// 		public void Get_All_Events_ReturnOkResult()
// 		{
// 			//Act
// 			var okResult = this.controller.Get();

// 			//Assert
// 			Assert.IsType<OkObjectResult>(okResult.Result);
// 		}
// 	}
// }