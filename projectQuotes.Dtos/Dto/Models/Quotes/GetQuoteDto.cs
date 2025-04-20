using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Dto.Users;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Quotes;

[ExportTsInterface]
public class GetQuoteDto : ModelDtoWithTimeStamp
{
   public required GetTextDto Text { get; set; }

    public required GetCharacterDto Character { get; set; }

    public required GetLightUserDto Creator { get; set; }

    public required List<GetTagDto> Tags { get; set; }

    public required string QuoteText { get; set; }

    public required string Context { get; set; }

    public required string Description { get; set; }


}
