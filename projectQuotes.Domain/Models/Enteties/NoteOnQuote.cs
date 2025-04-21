using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace projectQuotes.Domain.Models.Enteties;

public class NoteOnQuote : ModelWithTimeStamp
{
    public required virtual User Creator { get; set; }

    public required virtual Quote Quote { get; set; }


    [StringLength(NoteOnQuoteContstants.TextLength)]
    public required string Text { get; set; }

    public required bool IsPublished { get; set; }
}
