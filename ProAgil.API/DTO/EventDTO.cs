using System.Collections.Generic;

namespace ProAgil.API.DTO
{
    public class EventDTO
    {
			public int Id { get; set; }
			public string Place { get; set; }
			public string EventDate { get; set; }
			public string Theme { get; set; }
			public int PeopleAmount { get; set; }
			public List<LotDTO> Lots { get; set; }
			public string PhoneNumber { get; set;}
			public string Email {get; set; }
			public string ImageUrl { get; set; }
			public List<SocialMediaDTO> SocialMedias { get; set; }
			public List<SpeakerDTO> Speakers { get; set; }
    }
}