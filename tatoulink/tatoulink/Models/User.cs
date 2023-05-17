using System;
using System.Collections.Generic;

namespace tatoulink.Models;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Status { get; set; }

    public string? LastJobs { get; set; }

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
}
