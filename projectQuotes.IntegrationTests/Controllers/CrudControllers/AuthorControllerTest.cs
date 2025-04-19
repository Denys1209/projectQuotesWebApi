using Anytour.IntegrationTests.shared;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotes.Dtos.Shared;
using projectQuotes.Infrastructure.LinkFactories;
using projectQuotes.SharedModels.Models;
using projectQuotesWebApi.Application.Services.Models.Authors;
using projectQuotesWebApi.Controllers.Models;
using System.Diagnostics;

namespace projectQuotes.IntegrationTests.Controllers.CrudControllers;

public class AuthorControllerTest : BaseCrudControllerTest<GetAuthorDto, UpdateAuthorDto, CreateAuthorDto, IAuthorService, Author, GetAuthorDto, ReturnPageDto<GetAuthorDto>, AuthorController, SharedAuthorModels>
{
    public AuthorControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedAuthorModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<AuthorController> GetController(IServiceProvider alternativeServices)
    {
        return new AuthorController(alternativeServices.GetRequiredService<IAuthorService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

}
