﻿using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace projectQuotes.Domain.Models.Enteties;

public class Quote : ModelWithTimeStamp
{

    public  virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public  virtual ICollection<User> InFavoriteQuotes { get; set; } = new HashSet<User>();

    public required virtual Text Text { get; set; }

    public required virtual Character Character { get; set; }

    [ForeignKey(nameof(Creator))]
    public Guid CreatorId { get; set; }

    [NotMapped]
    public virtual User Creator { get; set; } = null!;

    [StringLength(QuoteConstants.QuoteTextLength)]
    public required string QuoteText { get; set; }


    [StringLength(QuoteConstants.ContextLength)]
    public required string Context { get; set; }


    [StringLength(QuoteConstants.DescriptionLength)]
    public required string Description { get; set; }

    public required bool IsPublished { get; set; }

}
