using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotes.Dtos.Dto.Users;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.NoteOnQuotes;

[ExportTsInterface]
public class GetNoteOnQuoteDto : ModelDtoWithTimeStamp
{
    public required  GetLightUserDto Creator { get; set; }

    public required GetQuoteDto Quote { get; set; }
    public required string Text { get; set; }

    public required bool IsPublished { get; set; }
}
