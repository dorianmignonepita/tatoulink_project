using System;
using System.Collections.Generic;

namespace tatoulink.DataAccess.EfModels;

public partial class JobOfferUser
{
    public int Id { get; set; }

    public int? JobOfferId { get; set; }

    public int? UserId { get; set; }

    public virtual JobOffer? JobOffer { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual User? User { get; set; }
}
