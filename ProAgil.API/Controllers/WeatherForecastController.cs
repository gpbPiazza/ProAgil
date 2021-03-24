using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.API.model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<Event> _logger;

        public WeatherForecastController(ILogger<Event> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return  new Event[] {
							new Event() {
								EventId = 1,
								Theme = "Festa do Zape",
								Place = "Palio do zape",
								Lot = "Único",
								PeopleAmount = 120,
								EventDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
							},
							new Event() {
								EventId = 2,
								Theme = "Festa do batman",
								Place = "Palio do zape sombrio",
								Lot = "Único",
								PeopleAmount = 320,
								EventDate = DateTime.Now.AddDays(6).ToString("dd/MM/yyyy"),
							},
								new Event() {
								EventId = 3,
								Theme = "Festa do batman",
								Place = "Palio do zape sombrio",
								Lot = "Único",
								PeopleAmount = 320,
								EventDate = DateTime.Now.AddDays(6).ToString("dd/MM/yyyy"),
							}
						};
        }
				//
				[HttpGet("{id}")]
				public ActionResult<Event> Get(int id) 
				{
					var events = new Event[] {
							new Event() {
								EventId = 1,
								Theme = "Festa do Zape",
								Place = "Palio do zape",
								Lot = "Único",
								PeopleAmount = 120,
								EventDate = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
							},
							new Event() {
								EventId = 2,
								Theme = "Festa do batman",
								Place = "Palio do zape sombrio",
								Lot = "Único",
								PeopleAmount = 320,
								EventDate = DateTime.Now.AddDays(6).ToString("dd/MM/yyyy"),
							}, 	new Event() {
								EventId = 3,
								Theme = "Festa do batman",
								Place = "Palio do zape sombrio",
								Lot = "Único",
								PeopleAmount = 320,
								EventDate = DateTime.Now.AddDays(6).ToString("dd/MM/yyyy"),
							}
					};

					var findEventById = events.FirstOrDefault(element => element.EventId == id);
					return  findEventById;
				}
    }
}
