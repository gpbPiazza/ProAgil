using System.Collections.Generic;

namespace ProAgil.Domain
{
	public class Speaker
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal CurriculumVitae { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public List<SocialMedia> SocialMedias { get; set; }
		public List<EventSpeaker> EventSpeakers { get; set; }
	}
}