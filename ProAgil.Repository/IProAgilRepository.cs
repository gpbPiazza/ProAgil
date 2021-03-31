using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
	public interface IProAgilRepository
	{
		void Add<T>(T entity) where T : class;
		void Update<T>(T entity) where T : class;
		void Delete<T>(T entity) where T : class;

		Task<bool> SaveChangesAsync();

		//EVENTS
		Task<Event[]> GetAllEventAsyncByTheme(string theme, bool includeSpeakers);
		Task<Event[]> GetAllEventAsync(bool includeSpeakers);
		Task<Event> GetEventAsyncById(int EventId, bool includeSpeakers);
		//Speakers
		Task<Speaker[]> GetAllSpeakersAsyncByName(string name, bool includeEvents);
		Task<Speaker> GetSpeakerAsyncById(int speakerId,  bool includeEvents);
	}
}