using System.Text;
using projectQuotes.Constants.Shared;
using projectQuotes.Domain.Models;
using projectQuotes.EfPersistence.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using projectQuotes.Constants.Shared;
using projectQuotes.Domain.Models;
using projectQuotes.EfPersistence.Data;

namespace projectQuotesWebApi.Extensions;

public static class AuthExtensions
{
    public static void AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
     "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзиийклмнопрстуфхцчшщъыьэюя" + // Lowercase Russian letters
     "АБВГДЕЄЖЗІЇЙКЛМНОПРСТУФХЦЧШЩЮЯабвгдежзіїйклмнопрстуфхцчшщюя0123456789! ";

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<AppDbContext>();
    }

    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration[AppSettingsStringConstants.JwtIssuer],
                    ValidAudience = configuration[AppSettingsStringConstants.JwtAudience],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration[AppSettingsStringConstants.JwtKey]!))
                };
            });
    }
}