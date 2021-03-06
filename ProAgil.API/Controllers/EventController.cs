using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.API.DTO;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{		
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{	
		private readonly IProAgilRepository repository;
		private readonly IMapper mapper;
		public EventController(
			IProAgilRepository repository,
			IMapper mapper
		)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var events = await repository.GetAllEventAsync(true);
				var results = this.mapper.Map<EventDTO[]>(events);
				return Ok(results);
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

				var results = this.mapper.Map<EventDTO>(Event);
				return Ok(results);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
		}

		[HttpPost("upload")]
		public async Task<IActionResult> upload()
		{
			try 
			{
				var file = Request.Form.Files[0];
				var folderName = Path.Combine("Resources", "Images");
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				if(file.Length > 0) 
				{
					var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
					var fullPath = Path.Combine(pathToSave, fileName.Replace("\"", " ".Trim()));
					using(var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					return Ok();
				}
			}
			catch (System.Exception ex)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, $"{ex}");
			}
			return BadRequest();
		}

		[HttpGet("getByTheme/{theme}")]
		public async Task<IActionResult> Get(string theme)
		{
			try
			{
				var events = await this.repository.GetAllEventAsyncByTheme(theme, true);
				var results = this.mapper.Map<EventDTO[]>(events);
				return Ok(results);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base ERROR");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(EventDTO model)
		{
			try
			{	
				var Event = this.mapper.Map<Event>(model); 
				this.repository.Add(Event);
				bool isEventRegistered = await this.repository.SaveChangesAsync();
				if(isEventRegistered)
				{
					var result = this.mapper.Map<EventDTO>(Event);
					return Created($"/api/event/{result.Id}", result);
				}
			}
			catch  (System.Exception ex) 
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, $"Data base ERROR {ex}");
			}
			return BadRequest();
		}

		[HttpPut("{EventId}")]
		public async Task<IActionResult> Put(int eventId, EventDTO model)
		{
			try
			{
				Event Event = await this.repository.GetEventAsyncById(eventId, false);
				if(Event == null) return NotFound();

				this.mapper.Map(model, Event);
				
				this.repository.Update(Event);
				bool isEventUpdated = await this.repository.SaveChangesAsync();
				if(isEventUpdated)
				{
					var result = this.mapper.Map<EventDTO>(Event);
					return Created($"/api/event/{result.Id}", result);
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
					return this.StatusCode(StatusCodes.Status200OK);
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