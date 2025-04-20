using projectQuotes.Domain.Models.Shared;
using projectQuotes.Dtos.Shared;

namespace projectQuotes.Dtos.Dto.Users;

public class GetLightUserDto : ModelDto
{
    public required string UserName { get; set; }
}
