using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.Tests
{
	public class ProAgilRepositoryFake : IProAgilRepository
	{
		public ProAgilRepositoryFake()
		{
			Event[] events = {
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
		}
		public void Add<T>(T entity) where T : class
		{
			throw new System.NotImplementedException();
		}

		public void Delete<T>(T entity) where T : class
		{
			throw new System.NotImplementedException();
		}

		public Task<Event[]> GetAllEventAsync(bool includeSpeakers)
		{
			// return this.Events;
			throw new System.NotImplementedException();
		}

		public Task<Event[]> GetAllEventAsyncByTheme(string theme, bool includeSpeakers)
		{
			throw new System.NotImplementedException();
		}

		public Task<Speaker[]> GetAllSpeakersAsyncByName(string name, bool includeEvents)
		{
			throw new System.NotImplementedException();
		}

		public Task<Event> GetEventAsyncById(int EventId, bool includeSpeakers)
		{
			throw new System.NotImplementedException();
		}

		public Task<Speaker> GetSpeakerAsyncById(int speakerId, bool includeEvents)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> SaveChangesAsync()
		{
			throw new System.NotImplementedException();
		}

		public void Update<T>(T entity) where T : class
		{
			throw new System.NotImplementedException();
		}
	}
}