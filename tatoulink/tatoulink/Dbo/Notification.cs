﻿using tatoulink.Dbo;

namespace tatoulink.Dbo
{
    public class Notification : IObjectWithId
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public int JobOfferUserId { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
