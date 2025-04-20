using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Charcters;


[ExportTsInterface]
public class GetCharacterDto : ModelDto
{
    public  required GetTextDto Text { get; set; }

    public required string Name { get; set; }

    public required string Slug { get; set; }

}
