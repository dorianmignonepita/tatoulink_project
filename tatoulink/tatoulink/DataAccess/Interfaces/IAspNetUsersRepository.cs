using tatoulink.DataAccess.EfModels;

namespace tatoulink.DataAccess.Interfaces
{
    public interface IAspNetUsersRepository
    {
        public Task<IEnumerable<Dbo.AspNetUsers>> Get(string includeTables = "");
    }
}
