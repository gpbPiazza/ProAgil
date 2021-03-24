using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.Data;
using ProAgil.API.model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProAgil.API.Controllers
{
	[ApiController]
	[Route("/api")]
	public class ValuesController : ControllerBase
	{
		public readonly DataContext Context;
		public ValuesController(DataContext context)
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
			return  await this.Context.Events.FirstOrDefaultAsync(element => element.EventId == id);
		}
	}
}
