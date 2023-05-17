using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace tatoulink.Models;

public partial class JobOffer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Le champ OfferName est requis.")]
    public string OfferName { get; set; }

    [Required(ErrorMessage = "Le champ Description est requis.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Le champ CreationDate est requis.")]
    public DateTime CreationDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Le champ Type doit être supérieur à 0.")]
    public int Type { get; set; }

    public string? Duration { get; set; }

    [Required(ErrorMessage = "Le champ ExpiringDate est requis.")]
    public DateTime ExpiringDate { get; set; }

    [Required(ErrorMessage = "Le champ CreatorId est requis.")]
    public int CreatorId { get; set; }

    public virtual User Creator { get; set; }

    public virtual ICollection<JobOfferUser> JobOfferUsers { get; set; }
}
