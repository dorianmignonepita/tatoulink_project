using tatoulink.Dbo;

namespace tatoulink.DTO
{
    public class JobOfferUser : IObjectWithId
    {
        public int Id { get; set; }

        public int? JobOfferId { get; set; }

        public int? UserId { get; set; }
    }
}
