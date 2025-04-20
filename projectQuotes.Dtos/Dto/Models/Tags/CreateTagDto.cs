using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Tags;


[ExportTsInterface]
[ModelMetadataType(typeof(Tag))]
public class CreateTagDto
{
    public  Guid? TextId { get; set; } 

    public required string Name { get; set; }

    public required string Slug { get; set; }

    public required string Describtion { get; set; }

}
