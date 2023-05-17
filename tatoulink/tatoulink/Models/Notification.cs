using System;
using System.Collections.Generic;

namespace tatoulink.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int JobOfferUserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual JobOfferUser JobOfferUser { get; set; } = null!;

    public virtual User Receiver { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
