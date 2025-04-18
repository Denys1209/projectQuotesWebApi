using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using projectQuotes.Domain.Models;
using projectQuotes.Constants.Shared;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace projectQuotes.Infrastructure.JwtTokenFactories;

public class JwtTokenFactory(
    IUserClaimsPrincipalFactory<User> claimsFactory
) : IJwtTokenFactory
{
    public async Task<string?> GetJwtTokenAsync(User user, IConfiguration configuration)
    {
        var claimsPrincipal = await claimsFactory.CreateAsync(user);




        Claim[] claims =
        [
            ..claimsPrincipal.Claims,
            new Claim(ClaimTypes.Name, user.UserName),



            new Claim("id", user.Id.ToString()),



            new Claim(JwtRegisteredClaimNames.Aud, configuration[AppSettingsStringConstants.JwtAudience]!),
            new Claim(JwtRegisteredClaimNames.Iss, configuration[AppSettingsStringConstants.JwtIssuer]!)
        ];
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration[AppSettingsStringConstants.JwtKey]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(SharedNumberConstatnts.HowManyDayExpiresForJwt),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }
}