using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Authors;


[ExportTsInterface]
[ModelMetadataType(typeof(Author))]
public class UpdateAuthorDto : ModelDto
{
    public required string Name { get; set; }
}

