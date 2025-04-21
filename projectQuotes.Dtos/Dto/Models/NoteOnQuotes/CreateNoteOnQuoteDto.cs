using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.NoteOnQuotes;

[ExportTsInterface]
[ModelMetadataType(typeof(NoteOnQuote))]
public class CreateNoteOnQuoteDto
{
    [EntityValidation(typeof(User))] public required Guid CreatorId { get; set; }

    [EntityValidation(typeof(Quote))] public required Guid QuoteId { get; set; }

    public required string Text { get; set; }

    public required bool IsPublished { get; set; }
}
