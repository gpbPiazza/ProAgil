namespace ProAgil.API.DTO
{
    public class LotDTO
    {
      public int Id { get; set; }
			public string Name { get; set; }
			public decimal Price { get; set; }
			public string BeginningDate { get; set; }
			public string EndDate { get; set; }
			public int Quantity { get; set; }
			public int EventId { get; set; }
			public EventDTO Event { get; }
    }
}