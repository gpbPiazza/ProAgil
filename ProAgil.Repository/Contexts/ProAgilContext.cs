using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Domain.Identities;

namespace ProAgil.Repository.Data
{
	public class ProAgilContext : IdentityDbContext<
		User, 
		Role, 
		int, 
		IdentityUserClaim<int>, 
		UserRole, 
		IdentityUserLogin<int>, 
		IdentityRoleClaim<int>, 
		IdentityUserToken<int>
	>
	{
		public ProAgilContext(DbContextOptions<ProAgilContext> options) : base (options) {}

		public DbSet<Event> Events { get; set; }
		public DbSet<Speaker> Speakers { get; set; }
		public DbSet<EventSpeaker> EventSpeakers { get; set; }
		public DbSet<SocialMedia> SocialMedias { get; set; }
		public DbSet<Lot> Lots { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<EventSpeaker>()
				.HasKey(eventUser => new {eventUser.EventId, eventUser.SpeakerId});

			modelBuilder.Entity<UserRole>(userRole => {
				userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

				userRole.HasOne(entity => entity.Role)
					.WithMany(r => r.UserRoles)
					.HasForeignKey(ur => ur.RoleId)
					.IsRequired();

				userRole.HasOne(entity => entity.User)
					.WithMany(r => r.UserRoles)
					.HasForeignKey(ur => ur.UserId)
					.IsRequired();
			});
		}
	}
}