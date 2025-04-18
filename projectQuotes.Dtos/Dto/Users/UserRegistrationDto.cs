using projectQuotes.Constants.Controller;
using projectQuotes.Constants.Models;
using projectQuotes.Dtos.MyOwnValidationAttributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Users;

[ExportTsInterface]
public class UserRegistrationDto
{
    [StringLength(UserConstants.NameLength, ErrorMessage = UserConstants.NameIsTooLongErrorMessage)]
    [UserNameAlreadyExist(ErrorMessage = UserConstants.UserNameAlreadyExistErrorMessage)]
    [Required]
    public required string UserName { get; set; }

    [EmailAddress(ErrorMessage = ControllerStringConstants.EmailIsntFormatedCorrectlyErrorMessage)]
    [EmailIsAlreadyExist(ErrorMessage = UserConstants.UserEmailAlreadyExistErrorMessage)]
    [Required]
    public required string Email { get; set; }

  
    [Required]
    [RegularExpression(UserConstants.SimplePasswordRegExpression,
        ErrorMessage = UserConstants.SimplePasswordErrorMessage)]
    public required string Password { get; set; }

    [Required]
    [RoleValidation(ErrorMessage = UserConstants.RoleDoesntExist)]
    public required string Role { get; set; }
}