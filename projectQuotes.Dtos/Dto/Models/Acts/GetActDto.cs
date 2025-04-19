using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Acts;

[ExportTsInterface]
public class GetActDto : ModelDto
{
    public required int Number {  get; set; }

    public required GetTextDto GetTextDto { get; set; }

    public required List<GetLightSceneDto> Scenes { get; set; } 
}
