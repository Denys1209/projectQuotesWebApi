using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace projectQuotes.Domain.Models.Enteties;

public class Tag : Model
{
    public virtual Text? Text { get; set; } 

    [StringLength(TagConstants.NameLength)]
    public required string Name { get; set; }

    [StringLength(TagConstants.SlugLength)]
    public required string Slug { get; set; }

    [StringLength(TagConstants.DescribtionLength)]
    public required string Describtion { get; set; }


}
