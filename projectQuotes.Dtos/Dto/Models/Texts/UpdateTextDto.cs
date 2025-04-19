using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Enums;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Texts;


[ExportTsInterface]
[ModelMetadataType(typeof(Text))]
public class UpdateTextDto : ModelDto
{
    public required string Name { get; set; }     

    public required string Summary { get; set; }

    public required TypeTextEnum Type { get; set; }

    [EntityValidation(typeof(Author))] public required Guid AuthorId { get; set; }

}
