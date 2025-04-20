using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace projectQuotes.Domain.Models.Enteties;

public class Quote : ModelWithTimeStamp
{

    public required virtual HashSet<Tag> Tags { get; set; } = new HashSet<Tag>();

    public required virtual Text Text { get; set; }

    public required virtual Character Character { get; set; }

    public required virtual User Creator { get; set; }

    [StringLength(QuoteConstants.QuoteTextLength)]
    public required string QuoteText { get; set; }


    [StringLength(QuoteConstants.ContextLength)]
    public required string Context { get; set; }


    [StringLength(QuoteConstants.DescriptionLength)]
    public required string Description { get; set; }
}
