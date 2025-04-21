using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.Acts;

namespace projectQuotes.SharedModels.Models;

public class SharedActModels : SharedModelsBase, IShareModels<CreateActDto, UpdateActDto, Act>

{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedTextModels.AddAllDependencies(services);
        services.AddScoped<IActRepository, ActRepository>();
        services.AddScoped<IActService, ActService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedActModels.GetSampleCreateDto();

        dto.TextId = await SharedTextModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        return await serviceProvider.GetService<IActService>().CreateAsync(dto, cancellationToken);
    }

    public static Act GetSample()
    {
        return new Act()
        {
            Number = 1,
            Text = SharedTextModels.GetSample(),
            Scenes = []
        };
    }

    public static CreateActDto GetSampleCreateDto()
    {
        return new CreateActDto()
        {
            Number = 2,
            TextId = Guid.NewGuid(),
        };
    }

    public static Act GetSampleForUpdate()
    {
        return new Act()
        {
            Number = 2,
            Text = SharedTextModels.GetSampleForUpdate(),
            Scenes = []
        };
    }

    public static UpdateActDto GetSampleUpdateDto()
    {
        return new UpdateActDto()
        {
            Number = 3,
            TextId= Guid.NewGuid(),
        };
    }
}
