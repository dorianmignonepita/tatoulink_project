using AutoMapper;
using tatoulink.DataAccess.EfModels;

namespace tatoulink.DataAccess.Repositories
{
    public class UserRepository : Repository<EfModels.User, Dbo.User>, Interfaces.IUserRepository
    {
        public UserRepository(DbContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }
    }
}
