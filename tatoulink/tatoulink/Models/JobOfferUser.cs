using System;
using System.Collections.Generic;

namespace tatoulink.Models;

public partial class JobOfferUser
{
    public int? JobOfferId { get; set; }

    public int? UserId { get; set; }

    public virtual JobOffer? JobOffer { get; set; }

    public virtual User? User { get; set; }
}
