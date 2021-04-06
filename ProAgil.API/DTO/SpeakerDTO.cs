using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTO
{
    public class SpeakerDTO
    {
			public int Id { get; set; }
			[Required]
			[MaxLength (150)]
			public string Name { get; set; }
			[Required]
			[MaxLength (255)]
			public string CurriculumVitae { get; set; }
			public string ImageUrl { get; set; }
			[Required]
			[EmailAddress]
			public string Email { get; set; }
			[Required]
			[Phone]
			public string PhoneNumber { get; set; }
			public List<SocialMediaDTO> SocialMedias { get; set; }
			public List<EventDTO> Events { get; set; }
    }
}