using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.DTO
{
    public class LotDTO
    {
      public int Id { get; set; }
			[Required]
			[MaxLength (255)]
			public string Name { get; set; }
			[Required]
			public decimal Price { get; set; }
			[Required]
			public string BeginningDate { get; set; }
			[Required]
			public string EndDate { get; set; }
			[Required]
			public int Quantity { get; set; }
			[Required]
			public int EventId { get; set; }
			public EventDTO Event { get; }
    }
}