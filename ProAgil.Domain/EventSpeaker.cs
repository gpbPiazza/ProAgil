namespace ProAgil.Domain
{
	public class EventSpeaker
	{
		public int Id { get; set; }
		public int EventId { get; set; }
		public Event Event { get; set; }
		public Speaker Speaker { get; set; }
		public int SpeakerId { get; set; }
	}
}