using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Quotes;


[ExportTsInterface]
[ModelMetadataType(typeof(Quote))]

public class UpdateQuoteDto :ModelDto
{
  [EntityValidation(typeof(Text))] public required Guid TextId { get; set; }

    [EntityValidation(typeof(Character))] public required Guid CharacterId { get; set; }

    [EntityValidation(typeof(User))] public required Guid CreatorId { get; set; }

     [EntityValidation(typeof(Tag))] public required List<Guid> TagIds { get; set; }

    public required string QuoteText { get; set; }

    public required string Context { get; set; }

    public required string Description { get; set; }

    public required bool IsPublished { get; set; }
}
