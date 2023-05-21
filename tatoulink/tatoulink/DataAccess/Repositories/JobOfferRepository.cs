using AutoMapper;
using tatoulink.DataAccess.EfModels;

namespace tatoulink.DataAccess.Repositories
{
    public class JobOfferRepository : Repository<EfModels.JobOffer, Dbo.JobOffer>, Interfaces.IJobOfferRepository
    {
        public JobOfferRepository(EfModels.DbContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
