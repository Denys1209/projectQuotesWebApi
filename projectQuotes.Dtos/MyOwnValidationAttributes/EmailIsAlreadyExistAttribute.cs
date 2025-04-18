using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Users;
using projectQuotes.Constants.Models;

namespace projectQuotes.Dtos.MyOwnValidationAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class EmailIsAlreadyExistAttribute : ValidationAttribute
{
    public EmailIsAlreadyExistAttribute()
    {
        ErrorMessage = UserConstants.UserEmailAlreadyExistErrorMessage;
    }

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return new ValidationResult(ErrorMessage);

        var email = (string)value;
        var userService = validationContext.GetRequiredService<IUserRepository>();

        return userService.CheckIfUserWithTheEmailIsAlreadyExist(email)
            ? new ValidationResult(ErrorMessage)
            : ValidationResult.Success!;
    }
}