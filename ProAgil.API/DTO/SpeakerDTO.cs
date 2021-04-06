using System.Collections.Generic;

namespace ProAgil.API.DTO
{
    public class SpeakerDTO
    {
			public int Id { get; set; }
			public string Name { get; set; }
			public string CurriculumVitae { get; set; }
			public string ImageUrl { get; set; }
			public string Email { get; set; }
			public string PhoneNumber { get; set; }
			public List<SocialMediaDTO> SocialMedias { get; set; }
			public List<EventDTO> Events { get; set; }
    }
}