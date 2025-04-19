using Anytour.IntegrationTests.shared;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotes.Dtos.Shared;
using projectQuotes.SharedModels.Models;
using projectQuotesWebApi.Application.Services.Models.Acts;
using projectQuotesWebApi.Application.Services.Models.Texts;
using projectQuotesWebApi.Controllers.Models;

namespace projectQuotes.IntegrationTests.Controllers.CrudControllers;

public class ActControllerTest : BaseCrudControllerTest<GetActDto, UpdateActDto, CreateActDto, IActService, Act, GetActDto, ReturnPageDto<GetActDto>, ActController, SharedActModels>
{
    public ActControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedActModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<ActController> GetController(IServiceProvider alternativeServices)
    {
        return new ActController(alternativeServices.GetRequiredService<IActService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override async Task MutationBeforeDtoCreation(CreateActDto createDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.TextId = textId;
    }

    protected override async Task MutationBeforeDtoUpdate(UpdateActDto updateDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.TextId = textId;
    }


}

