using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTO
{
	public class SocialMediaDTO
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string URL { get; set; }
  }
}