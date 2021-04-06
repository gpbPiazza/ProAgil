using System.Linq;
using AutoMapper;
using ProAgil.API.DTO;
using ProAgil.Domain;


namespace ProAgil.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
      public AutoMapperProfiles()
			{
				CreateMap<Event, EventDTO>()
					.ForMember(target => target.Speakers, options => { 
						options.MapFrom(source => source.EventSpeakers.Select(element => element.Speaker).ToList());
					}).ReverseMap();
				CreateMap<Speaker, SpeakerDTO>()
					.ForMember(target => target.Events, options => {
						options.MapFrom(source => source.EventSpeakers.Select(element => element).ToList());
					}).ReverseMap();
				CreateMap<Lot, LotDTO>().ReverseMap();
				CreateMap<SocialMedia, SocialMediaDTO>().ReverseMap();
			}
    }
}