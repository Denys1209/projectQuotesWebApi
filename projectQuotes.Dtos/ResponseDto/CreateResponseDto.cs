using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.ResponseDto;

[ExportTsInterface]
public class CreateResponseDto
{
    public Guid Id { get; set; }
}