using AutoMapper;
using tatoulink.DTO;
/*using tatoulink.Models;

namespace tatoulink.mapperProfil
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.JobOffer, DTO.JobOffer>();
            CreateMap<Models.User, DTO.User>();
            CreateMap<Models.JobOfferUser, DTO.JobApplication>()
                .ForMember(dest => dest.JobOfferId, opt => opt.MapFrom(src => src.JobOfferId.GetValueOrDefault()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.GetValueOrDefault()));
            CreateMap<JobOfferUser, DTO.CreatedJobOffer>()
                .ForMember(dest => dest.JobOfferId, opt => opt.MapFrom(src => src.JobOfferId.GetValueOrDefault()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.GetValueOrDefault()));
            CreateMap<Models.JobOffer, DTO.ModifiedJobOffer>()
                .ForMember(dest => dest.JobOfferId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedJobOfferElement, opt => opt.MapFrom(src => src));
            CreateMap<Models.JobOffer, DTO.JobOffer>();
            CreateMap<DTO.UserProfile, Models.User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Firstname, opt => opt.Ignore())
                .ForMember(dest => dest.Surname, opt => opt.Ignore())
                .ForMember(dest => dest.Birthdate, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.LastJobs, opt => opt.Ignore())
                .ForMember(dest => dest.JobOffers, opt => opt.Ignore());
        }
    }
}
*/