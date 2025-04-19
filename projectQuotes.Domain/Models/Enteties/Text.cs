using projectQuotes.Constants.Models;
using projectQuotes.Domain.Enums;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace projectQuotes.Domain.Models.Enteties;

public class Text : Model
{
    [StringLength(TextConstants.NameLength)]
    public required string Name { get; set; }     


    [StringLength(TextConstants.SummaryLength)]
    public required string Summary { get; set; }

    public required TypeTextEnum Type { get; set; }

    public required virtual Author Author { get; set; }
}
