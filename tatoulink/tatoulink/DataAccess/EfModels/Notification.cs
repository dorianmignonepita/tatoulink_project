using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tatoulink.DataAccess.EfModels;

public partial class Notification
{
    public int Id { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int JobOfferUserId { get; set; }

    [Required(ErrorMessage = "Le champ Message est requis.")]
    public string Message { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Timestamp est requis.")]
    public DateTime Timestamp { get; set; }

    [Required(ErrorMessage = "Le champ JobOfferUser est requis.")]
    public virtual JobOfferUser JobOfferUser { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Receiver est requis.")]
    public virtual User Receiver { get; set; } = null!;

    [Required(ErrorMessage = "Le champ Sender est requis.")]
    public virtual User Sender { get; set; } = null!;
}
