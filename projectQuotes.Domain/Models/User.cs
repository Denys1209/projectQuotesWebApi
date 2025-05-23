﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectQuotes.Domain.Models;

public class User : IdentityUser<Guid>, IModel, ICloneable
{
    [Required]
    public override required string Email
    {
        get => base.Email!;
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        set => base.Email = value;
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    }

    [StringLength(UserConstants.NameLength)]
    public override required string UserName { get => base.UserName; set => base.UserName = value; }

    public virtual ICollection<IdentityRole<Guid>> Roles { get; set; } = [];

    public string? ConfirmingCode { get; set; }

    public  virtual ICollection<Quote> FavoriteQuotes { get; set; } = new HashSet<Quote>();

    [NotMapped]
    public virtual ICollection<Quote> CreatedQuotes { get; set; } = new HashSet<Quote>();


    object ICloneable.Clone()
    {
        return Clone();
    }

    public User Clone()
    {
        return (User)MemberwiseClone();
    }


}
