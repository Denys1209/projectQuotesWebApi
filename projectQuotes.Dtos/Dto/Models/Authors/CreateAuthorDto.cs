using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Authors;

[ExportTsInterface]
[ModelMetadataType(typeof(Author))]
public class CreateAuthorDto
{

    public required string Name { get; set; }

}
