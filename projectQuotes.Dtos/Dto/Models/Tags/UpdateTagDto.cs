using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Shared;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Tags;


[ExportTsInterface]
[ModelMetadataType(typeof(Tag))]
public class UpdateTagDto : ModelDto
{
    public  Guid? TextId { get; set; } 

    public required string Name { get; set; }

    public required string Slug { get; set; }

    public required string Describtion { get; set; }

}
