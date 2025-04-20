using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Shared;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Charcters;


[ExportTsInterface]
[ModelMetadataType(typeof(Character))]
public class UpdateCharacterDto : ModelDto
{

    public required string Name { get; set; }

    public required string Slug { get; set; }

    [EntityValidation(typeof(Text))] public required Guid TextId { get; set; }

}
