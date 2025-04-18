using projectQuotes.Domain.Models;
using projectQuotes.Dtos.Dto.Users;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Users;

public interface IUserService : ICrudService<
    GetUserDto,
    UserRegistrationDto,
    UpdateUserDto,
    User,
    GetUserDto>
{

    public Task<string?> RegisterUserWithCodeAsync(UserRegistrationDto user, CancellationToken cancellationToken);

    public Task<Guid?> RegisterUserAsync(UserRegistrationDto user, CancellationToken cancellationToken);
    public Task<User?> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken);

    public Task<User?> AuthenticateUserWithAdminRoleAsync(string email, string password,
        CancellationToken cancellationToken);

    public Task<bool> CheckIfUserWithTheEmailIsAlreadyExistAsync(string email, CancellationToken cancellationToken);
    public bool CheckIfUserWithTheEmailIsAlreadyExist(string email);

    public Task<bool> CheckIfUserWithTheUserNameIsAlreadyExistAsync(string username,
        CancellationToken cancellationToken);

    public bool CheckIfUserWithTheUserNameIsAlreadyExist(string username);

    public Task<bool> ConfirmEmailAsync(string email, string code, CancellationToken cancellationToken);

}