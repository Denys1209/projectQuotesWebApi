using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectQuotes.Constants.Controller;
using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Users;

[ModelMetadataType(typeof(User))]
[ExportTsInterface]
public class UpdateUserDto : ModelDto
{


    [Required]
    [EmailAddress(ErrorMessage = ControllerStringConstants.EmailIsntFormatedCorrectlyErrorMessage)]
    public required string Email { get; set; }

    [Required]
    [RoleValidation(ErrorMessage = UserConstants.RoleDoesntExist)]
    public required string Role { get; set; }

    public required string UserName { get; set; }

}