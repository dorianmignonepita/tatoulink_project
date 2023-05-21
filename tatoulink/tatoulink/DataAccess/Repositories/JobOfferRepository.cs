using AutoMapper;
using tatoulink.DataAccess.EfModels;

namespace tatoulink.DataAccess.Repositories
{
    public class JobOfferRepository : Repository<EfModels.JobOffer, Dbo.JobOffer>, Interfaces.IJobOfferRepository
    {
        public JobOfferRepository(DbContext context, ILogger<JobOfferRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
