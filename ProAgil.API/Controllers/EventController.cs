using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{		
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{	
		private readonly IProAgilRepository repository;
		public EventController(IProAgilRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var events = await repository.GetAllEventAsync(true);
				return Ok(events);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
		}

		[HttpGet("{EventId}")]
		public async Task<IActionResult> Get(int EventId)
		{
			try 
			{
				var Event = await this.repository.GetEventAsyncById(EventId, true);
				if(Event == null) return NotFound();
				return Ok(Event);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
		}

		[HttpGet("getByTheme/{theme}")]
		public async Task<IActionResult> Get(string theme)
		{
			try
			{
				var events = await this.repository.GetAllEventAsyncByTheme(theme, true);
				return Ok(events);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(Event Event)
		{
			try
			{	
				this.repository.Add(Event);
				bool isEventRegistered = await this.repository.SaveChangesAsync();
				if(isEventRegistered)
				{
					return Created($"/api/event/{Event.Id}", Event);
				}
			}
			catch  (System.Exception) 
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
			return BadRequest();
		}

		[HttpPut("{EventId}")]
		public async Task<IActionResult> Put(int EventId, Event EventToUpdate)
		{
			try
			{
				Event Event = await this.repository.GetEventAsyncById(EventId, false);
				if(Event == null) return NotFound();

				this.repository.Update(EventToUpdate);
				bool isEventUpdated = await this.repository.SaveChangesAsync();
				if(isEventUpdated)
				{
					return Created($"/api/event/{EventToUpdate.Id}", EventToUpdate);
				}
			}
			catch  (System.Exception) 
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
			return BadRequest();
		}	

		[HttpDelete("{EventId}")]
		public async Task<IActionResult> Delete(int EventId)
		{
			try
			{
				Event Event = await this.repository.GetEventAsyncById(EventId, false);
				if (Event == null) return NotFound();

				this.repository.Delete(Event);
				bool isEventDeleted = await this.repository.SaveChangesAsync();
				if(isEventDeleted)
				{
					return Ok("Event deleted");
				}
			}
			catch(System.Exception) 
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
			return this.StatusCode(StatusCodes.Status400BadRequest);
		}
	}
}