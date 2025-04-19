using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.Scenes;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class SceneServiceTest : SharedServiceTest<
    GetSceneDto,
    CreateSceneDto,
    UpdateSceneDto,
    Scene,
    GetLightSceneDto,
    SceneRepository,
    SceneService,
    SharedSceneModels>
{

    protected override SceneService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new SceneService(builder.GetRequiredService<ISceneRepository>(), builder.GetRequiredService<IActRepository>(), Mapper);
    }
}
