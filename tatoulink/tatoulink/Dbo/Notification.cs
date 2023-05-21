using tatoulink.Dbo;

namespace tatoulink.Dbo
{
    public class Notification : IObjectWithId
    {
        public int Id { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public int JobOfferUserId { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
