using System;

namespace ProAgil.Domain
{
	public class Lot
	{
			public int Id { get; set; }
			public string Name { get; set; }
			public decimal Price { get; set; }
			public DateTime? BeginningDate { get; set; }
			public DateTime? EndDate { get; set; }
			public int Quantity { get; set; }
			public int EventId { get; set; }
			public Event Event { get; set; }
	}
}