using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Tags;

[ExportTsInterface]
public class GetTagDto : ModelDto
{
    public  GetTextDto? Text { get; set; } 

    public required string Name { get; set; }

    public required string Slug { get; set; }

    public required string Describtion { get; set; }


}
