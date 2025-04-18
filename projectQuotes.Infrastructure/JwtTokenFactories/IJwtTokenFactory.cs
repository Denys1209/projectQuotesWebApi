using projectQuotes.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace projectQuotes.Infrastructure.JwtTokenFactories;

public interface IJwtTokenFactory
{
    public Task<string?> GetJwtTokenAsync(User user, IConfiguration configuration);
}