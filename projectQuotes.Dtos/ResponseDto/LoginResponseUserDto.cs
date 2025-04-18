using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.ResponseDto;

[ExportTsInterface]
public class LoginResponseUserDto
{
    public required string Token { get; set; }
}