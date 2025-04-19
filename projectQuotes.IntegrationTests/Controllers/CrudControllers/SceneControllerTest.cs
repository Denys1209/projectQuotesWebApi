using Anytour.IntegrationTests.shared;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotes.Dtos.Shared;
using projectQuotes.SharedModels.Models;
using projectQuotesWebApi.Application.Services.Models.Scenes;
using projectQuotesWebApi.Controllers.Models;

namespace projectQuotes.IntegrationTests.Controllers.CrudControllers;

public class SceneControllerTest: BaseCrudControllerTest<GetSceneDto, UpdateSceneDto, CreateSceneDto, ISceneService, Scene, GetLightSceneDto, ReturnPageDto<GetLightSceneDto>, SceneController, SharedSceneModels>
{
    public SceneControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedSceneModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<SceneController> GetController(IServiceProvider alternativeServices)
    {
        return new SceneController(alternativeServices.GetRequiredService<ISceneService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override async Task MutationBeforeDtoCreation(CreateSceneDto createDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedActModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.ActId = textId;
    }

    protected override async Task MutationBeforeDtoUpdate(UpdateSceneDto updateDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedActModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.ActId = textId;
    }


}

