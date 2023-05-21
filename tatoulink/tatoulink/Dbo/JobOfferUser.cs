using tatoulink.Dbo;

namespace tatoulink.Dbo
{
    public class JobOfferUser : IObjectWithId
    {
        public int Id { get; set; }

        public int? JobOfferId { get; set; }

        public string UserId { get; set; }
    }
}
