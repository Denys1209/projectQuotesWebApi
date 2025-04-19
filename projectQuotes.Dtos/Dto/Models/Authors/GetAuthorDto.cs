using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Shared;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Models.Authors;

[ExportTsInterface]
public class GetAuthorDto : ModelDto
{
    public required string Name { get; set; }
}
