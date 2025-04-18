using projectQuotes.Constants.Models;
using System.ComponentModel.DataAnnotations;

namespace projectQuotes.Dtos.MyOwnValidationAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class RoleValidationAttribute : ValidationAttribute
{
    public RoleValidationAttribute()
    {
        ErrorMessage = UserConstants.UserRoleIsNotValidErrorMessage;
    }

    public override bool IsValid(object? value)
    {
        if (value == null) return false;

        var role = (value as string)!.ToLower();

        return UserConstants.UsersRolesList.Contains(role);
    }
}