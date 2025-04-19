using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Acts;



[ExportTsInterface]
[ModelMetadataType(typeof(Act))]
public class CreateActDto
{
    public required int Number { get; set; }
    [EntityValidation(typeof(Text))] public required Guid TextId { get; set; }
}
