using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tatoulink.DataAccess.EfModels;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le champ Firstname est requis.")]
    public string Firstname { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Surname est requis.")]
    public string Surname { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Birthdate est requis.")]
    public DateTime Birthdate { get; set; }

    [Required(ErrorMessage = "Le champ Password est requis.")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Email est requis.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Status est requis.")]
    public int Status { get; set; }

    public string? LastJobs { get; set; }

    public virtual ICollection<JobOfferUser> JobOfferUsers { get; set; } = new List<JobOfferUser>();

    public virtual ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();

    public virtual ICollection<Notification> NotificationReceivers { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationSenders { get; set; } = new List<Notification>();
}
