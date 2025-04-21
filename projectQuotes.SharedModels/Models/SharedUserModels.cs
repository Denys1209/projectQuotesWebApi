using projectQuotes.Application.Repositories.Users;
using projectQuotes.Domain.Models;
using projectQuotes.Dtos.Dto.Users;
using projectQuotes.EfPersistence.Repositories;
using projectQuotes.SharedModels.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using projectQuotesWebApi.Application.Services.Users;
using projectQuotes.Constants.Models;

namespace projectQuotes.SharedModels.Models;

public class SharedUserModels : SharedModelsBase, IShareModels<UserRegistrationDto, UpdateUserDto, User>
{

    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        SharedQuoteModels.AddAllDependencies(services);
    }


    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var user = SharedUserModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IUserService>().CreateAsync(user, cancellationToken);
    }

    public static User GetSample()
    {
        return new User()
        {
            Email = "test@gmail.com",
            UserName = "Test",
            PasswordHash = "test",
            FavoriteQuotes = []

        };

    }

    public static User GetSampleForUpdate()
    {
        return new User()
        {
            Email = "test1@gmail.com",
            UserName = "Test",
            PasswordHash = "test",
            FavoriteQuotes = []
        };
    }
    public static UserRegistrationDto GetSampleCreateDto()
    {
        return new UserRegistrationDto()
        {
            Email = "test1@gmail.com",
            Password = "test",
            Role = UserConstants.AdminRole,
            UserName = "userName"
        };
    }

    public static UserRegistrationDto GetUserRegistrationDtoForAdminSample()
    {
        return new UserRegistrationDto
        {
            Email = "Admin123@gmail.com",
            Password = "test123",
            Role = UserConstants.AdminRole,
            UserName = "UserNameAdmin"
        };
    }

    public static UserRegistrationDto GetUserRegistrationDtoForUserSample()
    {
        return new UserRegistrationDto
        {
            Email = "user123@gmail.com",
            Password = "test123",
            Role = UserConstants.UserRole,
            UserName = "UserNameUser"
        };
    }


    public static UpdateUserDto GetSampleUpdateDto()
    {
        return new UpdateUserDto()
        {
            Email = "test1@gmail.com",
            UserName = "Test",
            Role = UserConstants.AdminRole,
        };
    }

   }
