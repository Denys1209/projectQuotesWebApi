using Microsoft.EntityFrameworkCore;
using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace projectQuotes.Domain.Models.Enteties;

public class Author : Model
{
    [StringLength(AuthorConstants.NameLength)]
    public required string Name { get; set; }
}
