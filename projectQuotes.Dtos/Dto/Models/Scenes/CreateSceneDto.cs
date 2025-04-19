using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Scenes;

[ExportTsInterface]
[ModelMetadataType(typeof(Scene))]
public class CreateSceneDto  
{
    public required int Number { get; set; }
    public required string WholeText { get; set; }
    [EntityValidation(typeof(Act))] public required Guid ActId { get; set; }
}
