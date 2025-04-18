using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Users;
using projectQuotes.Constants.Models;

namespace projectQuotes.Dtos.MyOwnValidationAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class UserNameAlreadyExistAttribute : ValidationAttribute
{
    public UserNameAlreadyExistAttribute()
    {
        ErrorMessage = UserConstants.UserNameAlreadyExistErrorMessage;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return new ValidationResult(ErrorMessage);

        var username = (string)value;
        var userService = validationContext.GetRequiredService<IUserRepository>();

        return userService.CheckIfUserWithTheUserNameIsAlreadyExist(username)
            ? new ValidationResult(ErrorMessage)
            : ValidationResult.Success!;
    }
}