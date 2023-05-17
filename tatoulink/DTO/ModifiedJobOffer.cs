namespace tatoulink.DTO
{
    public class ModifiedJobOffer
    {
        public int JobOfferId { get; set; }
        public int UserId { get; set; }
        public JobOffer ModifiedJobOfferElement { get; set; }
    }
}
