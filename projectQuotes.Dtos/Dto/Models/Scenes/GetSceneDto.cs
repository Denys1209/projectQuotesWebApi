using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Scenes;

[ExportTsInterface]
public class GetSceneDto : ModelDto
{
    public required int Number { get; set; }

    public required string WholeText { get; set; }
    public required GetActDto Act { get; set; }
}
