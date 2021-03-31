using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Repository.Data;
using System.Linq;

namespace ProAgil.Repository
{
	public class ProAgilRepository : IProAgilRepository
	{
		private readonly ProAgilContext context;
		public ProAgilRepository(ProAgilContext context)
		{
			this.context = context;
		}


		public void Add<T>(T entity) where T : class
		{
			this.context.Add(entity);
		}
		public void Update<T>(T entity) where T : class
		{
			this.context.Update(entity);
		}
		public void Delete<T>(T entity) where T : class
		{
			this.context.Remove(entity);
		}

		public async Task<bool> SaveChangesAsync()
		{	
			return (await this.context.SaveChangesAsync()) > 0;
		}
		public async Task<Event[]> GetAllEventAsync(bool includeSpeakers = false)
		{
			IQueryable<Event> query = this.context.Events
				.Include(table => table.Lots)
				.Include(table => table.SocialMedias);

			if(includeSpeakers)
			{
				query = query
					.Include(table => table.EventSpeakers)
					.ThenInclude(table => table.Speaker);
			}

			query = query.OrderByDescending(orderBy => orderBy.EventDate);

			return await query.ToArrayAsync();
		}
		public async Task<Event> GetEventAsyncById(int EventId, bool includeSpeakers)
		{
			IQueryable<Event> query = this.context.Events
				.Include(column => column.Lots)
				.Include(table => table.SocialMedias);

			if(includeSpeakers)
			{
				query = query
					.Include(table => table.EventSpeakers)
					.ThenInclude(table => table.Speaker);
			}

			query = query
				.OrderByDescending(orderBy => orderBy.EventDate)
				.Where(column => column.Id == EventId);

			return await query.FirstOrDefaultAsync();
		}

		public async Task<Event[]> GetAllEventAsyncByTheme(string theme, bool includeSpeakers)
		{
				IQueryable<Event> query = this.context.Events
				.Include(column => column.Lots)
				.Include(table => table.SocialMedias);

			if(includeSpeakers)
			{
				query = query
					.Include(table => table.EventSpeakers)
					.ThenInclude(table => table.Speaker);
			}

			query = query
				.OrderByDescending(orderBy => orderBy.EventDate)
				.Where(column => column.Theme.ToLower().Contains(theme.ToLower()));

			return await query.ToArrayAsync();
		}

		public async Task<Speaker> GetSpeakerAsyncById(int speakerId, bool includeEvents = false)
		{
			IQueryable<Speaker> query = this.context.Speakers
				.Include(table => table.SocialMedias);

			if(includeEvents)
			{
				query = query
					.Include(table => table.EventSpeakers)
					.ThenInclude(table => table.Event);
			}

			query = query
				.OrderBy(column => column.Name)
				.Where(column => column.Id == speakerId);
			return await query.FirstOrDefaultAsync();
		}
		public async Task<Speaker[]> GetAllSpeakersAsyncByName(string name,  bool includeEvents = false)
		{
			IQueryable<Speaker> query = this.context.Speakers
				.Include(table => table.SocialMedias);
			
			if(includeEvents)
			{
				query = query
					.Include(table => table.EventSpeakers)
					.ThenInclude(table => table.Event);
			}

			query = query.Where(column => column.Name.ToLower().Contains(name.ToLower()));

			return await query.ToArrayAsync();
		}
	}
}