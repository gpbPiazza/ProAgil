using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
	public class Event
	{
		public int Id { get; set; }
		public string Place { get; set; }
		public DateTime EventDate { get; set; }
		public string Theme { get; set; }
		public int PeopleAmount { get; set; }
		public List<Lot> Lots { get; set; }
		public string PhoneNumber { get; set;}
		public string Email {get; set; }
		public string ImageUrl { get; set; }
		public List<SocialMedia> SocialMedias { get; set; }

		public List<EventSpeaker> EventSpeakers { get; set; }
	}
}