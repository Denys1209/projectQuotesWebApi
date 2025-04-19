using projectQuotes.Domain.Enums;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotes.Dtos.Shared;

namespace projectQuotes.Dtos.Dto.Models.Texts;

public class GetTextDto : ModelDto
{
    public required string Name { get; set; }     

    public required string Summary { get; set; }

    public required TypeTextEnum Type { get; set; }

    public required GetAuthorDto Author { get; set; }


}
