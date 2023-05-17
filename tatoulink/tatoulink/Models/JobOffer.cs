using System;
using System.Collections.Generic;

namespace tatoulink.Models;

public partial class JobOffer
{
    public int Id { get; set; }

    public string OfferName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public int Type { get; set; }

    public string? Duration { get; set; }

    public DateTime ExpiringDate { get; set; }

    public int CreatorId { get; set; }

    public virtual User Creator { get; set; } = null!;
}
