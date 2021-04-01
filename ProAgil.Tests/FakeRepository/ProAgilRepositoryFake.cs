namespace ProAgil.Tests.FakeRepository
{
	public class ProAgilRepositoryFake: IProAgilRepository
	{
	private readonly List<Event> Events;
	public ProAgilRepositoryFake() => 
		this.Events = new List<Event>(){
			new Event() {
				Place = "Rio de Janeiro",
				EventDate = "2021-05-29T21:24:36+00:00",
				Theme = ".NET core",
				PeopleAmount = 230,
				ImageUrl = "img3.jpg",
				PhoneNumber = "97845655",
				Email =  "dotnetCore@dotnetCore.com.br",
			},
				new Event() {
				Place = "Mock Janeiro",
				EventDate = "2021-05-29T21:24:36+00:00",
				Theme = "Mock .NET core",
				PeopleAmount = 230,
				ImageUrl = "Mockimg3.jpg",
				PhoneNumber = "97845655",
				Email =  "MockdotnetCore@dotnetCore.com.br",
			}
		};
		public IEnumeralbe<Event> GetAllEventAsync()
		{
			return this.Events;
		}
	}
}