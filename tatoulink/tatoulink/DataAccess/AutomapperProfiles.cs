using AutoMapper;

namespace tatoulink.DataAccess
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Dbo.JobOffer, EfModels.JobOffer>();
            CreateMap<EfModels.JobOffer, Dbo.JobOffer>();

            CreateMap<Dbo.JobOfferUser, EfModels.JobOfferUser>();
            CreateMap<EfModels.JobOfferUser, Dbo.JobOfferUser>();

            CreateMap<Dbo.Notification, EfModels.Notification>();
            CreateMap<EfModels.Notification, Dbo.Notification>();

            CreateMap<Dbo.AspNetUsers, EfModels.AspNetUsers>();
            CreateMap<EfModels.AspNetUsers, Dbo.AspNetUsers>();
        }
    }
}
