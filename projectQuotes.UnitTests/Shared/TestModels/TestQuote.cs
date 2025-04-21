using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using projectQuotes.Domain.Models;

namespace projectQuotes.UnitTests.Shared.TestModels;

public class TestQuote : ModelWithTimeStamp
{
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    public virtual ICollection<User> InFavoriteQuotes { get; set; } = new HashSet<User>();

    public required virtual Text Text { get; set; }

    public required virtual Character Character { get; set; }

    public Guid CreatorId { get; set; }


    [StringLength(QuoteConstants.QuoteTextLength)]
    public required string QuoteText { get; set; }


    [StringLength(QuoteConstants.ContextLength)]
    public required string Context { get; set; }


    [StringLength(QuoteConstants.DescriptionLength)]
    public required string Description { get; set; }

    public required bool IsPublished { get; set; }
}
