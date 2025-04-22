using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Charcters;

[TsDefaultExport]
public class GetLightCharacterDto : ModelDto
{
    public required string Name { get; set; }

    public required string Slug { get; set; }

}
