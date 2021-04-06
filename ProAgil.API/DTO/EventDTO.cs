using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTO
{
    public class EventDTO
    {
			public int Id { get; set; }
			[Required]
			[MaxLength (255)]
			public string Place { get; set; }
			[Required]
			public string EventDate { get; set; }
			[Required]
			[MaxLength (50)]
			public string Theme { get; set; }
			[Required]
			[Range(2, 1200, ErrorMessage="quantity of people range is 2 until 1200")]
			public int PeopleAmount { get; set; }
			public List<LotDTO> Lots { get; set; }
			[Required]
			public string PhoneNumber { get; set;}
			[Required]
			[EmailAddress]
			public string Email {get; set; }
			public string ImageUrl { get; set; }
			public List<SocialMediaDTO> SocialMedias { get; set; }
			public List<SpeakerDTO> Speakers { get; set; }
    }
}