using AutoMapper;
using tatoulink.DataAccess.Interfaces;
using tatoulink.Dbo;

namespace tatoulink.DataAccess.Repositories
{
    public class AspNetUsersRepository :  Interfaces.IAspNetUsersRepository
    {
        protected EfModels.DbContext _context;
        protected ILogger _logger;
        protected readonly IMapper _mapper;

        public AspNetUsersRepository(EfModels.DbContext context, ILogger logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }


        Task<IEnumerable<Dbo.AspNetUsers>> IAspNetUsersRepository.Get(string includeTables)
        {
            return (Task<IEnumerable<AspNetUsers>>)_context.AspNetUsers.AsEnumerable();
        }
    }
}
