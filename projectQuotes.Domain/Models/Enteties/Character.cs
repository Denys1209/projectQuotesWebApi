using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace projectQuotes.Domain.Models.Enteties;

public class Character : Model
{
    public virtual required Text Text { get; set; }


    [StringLength(CharacterConstants.NameLength)]
    public required string Name { get; set; }

    [StringLength(CharacterConstants.SlugLength)]
    public required string Slug { get; set; }
}
