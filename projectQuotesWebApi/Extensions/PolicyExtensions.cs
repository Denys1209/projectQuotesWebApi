using projectQuotes.Constants.Controller;
using projectQuotes.Constants.Shared;
using Microsoft.AspNetCore.Authorization;
using projectQuotesWebApi.Extensions;
using projectQuotes.Constants.Models;

namespace projectQuotesWebApi.Extensions;

public static class PolicyExtensions
{
    public static void AddPolicies(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy(ControllerStringConstants.CanAccessUserAndAdmin, policy =>
                policy.RequireRole(UserConstants.AdminRole, UserConstants.UserRole)
                    )
            .AddPolicy(ControllerStringConstants.CanAccessOnlyAdmin, policy =>
                policy.RequireRole(UserConstants.AdminRole)
                    .NotInRole(UserConstants.UserRole));
    }

    public static AuthorizationPolicyBuilder NotInRole(this AuthorizationPolicyBuilder policy, params string[] roles)
    {
        return policy.RequireAssertion(context =>
        {
            var user = context.User;
            return !roles.Any(role => user.IsInRole(role));
        });
    }
}