using AutoMapper;
using tatoulink.DataAccess.EfModels;

namespace tatoulink.DataAccess.Repositories
{
    public class JobOfferUserRepository : Repository<EfModels.JobOfferUser, Dbo.JobOfferUser>, Interfaces.IJobOfferUserRepository
    {
        public JobOfferUserRepository(EfModels.DbContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
