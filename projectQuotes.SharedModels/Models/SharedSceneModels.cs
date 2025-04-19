using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.Scenes;

namespace projectQuotes.SharedModels.Models;

public class SharedSceneModels : SharedModelsBase, IShareModels<CreateSceneDto, UpdateSceneDto, Scene>

{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedActModels.AddAllDependencies(services);
        services.AddScoped<ISceneRepository, SceneRepository>();
        services.AddScoped<ISceneService, SceneService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedSceneModels.GetSampleCreateDto();

        dto.ActId = await SharedActModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        return await serviceProvider.GetService<ISceneService>().CreateAsync(dto, cancellationToken);
    }

    public static Scene GetSample()
    {
        return new Scene()
        {
            Number = 1,
            Act = SharedActModels.GetSample(),
            WholeText = "sdafasfasfas"
            
        };
    }

    public static CreateSceneDto GetSampleCreateDto()
    {
        return new CreateSceneDto()
        {
            Number = 2,
            ActId = Guid.NewGuid(),
            WholeText = "dsdadsasdasddafasfasfas"
        };
    }

    public static Scene GetSampleForUpdate()
    {
        return new Scene()
        {
            Number = 2,
            Act = SharedActModels.GetSampleForUpdate(),
            WholeText = "update"
        };
    }

    public static UpdateSceneDto GetSampleUpdateDto()
    {
        return new UpdateSceneDto()
        {
            Number = 3,
            ActId= Guid.NewGuid(),
            WholeText = "saasa"
        };
    }
}
