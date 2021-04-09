using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository.Data
{
	public class ProAgilContext : DbContext
	{
		public ProAgilContext(DbContextOptions<ProAgilContext> options) : base (options) {}

		public DbSet<Event> Events { get; set; }
		public DbSet<Speaker> Speakers { get; set; }
		public DbSet<EventSpeaker> EventSpeakers { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }
		public DbSet<Lot> Lots { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EventSpeaker>()
				.HasKey(PK => new {PK.EventId, PK.SpeakerId});
		}
	}
}