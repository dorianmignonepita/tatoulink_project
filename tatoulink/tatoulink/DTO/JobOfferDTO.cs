namespace tatoulink.DTO
{
    public class JobOfferDTO
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Type { get; set; }
        public string Duration { get; set; }
        public DateTime ExpiringDate { get; set; }
        public int CreatorId { get; set; }
    }
}
