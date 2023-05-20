using AutoMapper;
using tatoulink.Dbo;
using tatoulink.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<JobOffer, JobOfferDTO>();
        CreateMap<JobOfferDTO, JobOffer>();
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
        CreateMap<JobOfferUser, JobOfferUserDTO>();
        CreateMap<JobOfferUserDTO, JobOfferUser>();
        CreateMap<Notification, Notification>();
        CreateMap<Notification, Notification>();
    }
}