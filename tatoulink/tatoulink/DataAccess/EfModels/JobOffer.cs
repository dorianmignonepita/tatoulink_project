using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tatoulink.DataAccess.EfModels;

public partial class JobOffer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le champ OfferName est requis.")]
    public string OfferName { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Description est requis.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Le champ CreationDate est requis.")]
    public DateTime CreationDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Le champ Type doit être supérieur à 0.")]
    public int Type { get; set; }

    public string? Duration { get; set; }

    [Required(ErrorMessage = "Le champ ExpiringDate est requis.")]
    public DateTime ExpiringDate { get; set; }

    [Required(ErrorMessage = "Le champ CreatorId est requis.")]
    public int CreatorId { get; set; }

    public virtual AspNetUsers Creator { get; set; } = null!;

    public virtual ICollection<JobOfferUser> JobOfferUsers { get; set; } = new List<JobOfferUser>();
}
