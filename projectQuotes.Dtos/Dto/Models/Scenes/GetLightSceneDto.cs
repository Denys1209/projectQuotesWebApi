using projectQuotes.Domain.Models.Shared;
using projectQuotes.Dtos.Shared;

namespace projectQuotes.Dtos.Dto.Models.Scenes;

public class GetLightSceneDto : ModelDto
{
    public required int Number { get; set; }

}
