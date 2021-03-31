using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpeakerController : ControllerBase
	{
		private readonly IProAgilRepository repository;
		public SpeakerController(IProAgilRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet("{SpeakerId}")]
		public async Task<IActionResult> Get(int SpeakerId)
		{
			try 
			{
				var Speaker = await this.repository.GetSpeakerAsyncById(SpeakerId, true);
				if(Speaker == null) return this.StatusCode(StatusCodes.Status404NotFound);
				return Ok(Speaker);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base Error!");
			}
		}

		[HttpGet("getByName/{SpeakerName}")]
		public async Task<IActionResult> Get(string SpeakerName)
		{
			try
			{
				var Speakers = await this.repository.GetAllSpeakersAsyncByName(SpeakerName, true);
				return Ok(Speakers);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base Error!");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(Speaker Speaker)
		{
			try
			{
				this.repository.Add(Speaker);
				bool isSpeakerRegistered = await this.repository.SaveChangesAsync();
				if(isSpeakerRegistered) return Created($"api/speaker/{Speaker.Id}", Speaker);
			}
			catch (System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base Error!");
			}
			return this.StatusCode(StatusCodes.Status400BadRequest);
		}

		[HttpDelete("{SpeakerId}")]
		public async Task<IActionResult> Delete(int SpeakerId)
		{
			try
			{
				Speaker Speaker = await this.repository.GetSpeakerAsyncById(SpeakerId, false);
				if(Speaker == null) return this.StatusCode(StatusCodes.Status404NotFound);
			
				this.repository.Delete(Speaker);
				bool isSpeakerDeleted = await this.repository.SaveChangesAsync();
				if(isSpeakerDeleted) return Ok("Speaker Deleted");
			}
			catch(System.Exception)
			{
				return this.StatusCode(StatusCodes.Status500InternalServerError, "Data base Error!");
			}
			return this.StatusCode(StatusCodes.Status400BadRequest);
		}
	}
}