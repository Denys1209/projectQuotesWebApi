using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.Chracters;

namespace projectQuotes.SharedModels.Models;

public class SharedCharacterModels : SharedModelsBase, IShareModels<CreateCharacterDto, UpdateCharacterDto, Character>

{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedTextModels.AddAllDependencies(services);
        services.AddScoped<ICharacterRepository, CharacterRepository>();
        services.AddScoped<ICharacterService, CharacterService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedCharacterModels.GetSampleCreateDto();

        dto.TextId = await SharedTextModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        return await serviceProvider.GetService<ICharacterService>().CreateAsync(dto, cancellationToken);
    }

    public static Character GetSample()
    {
        return new Character()
        {
            Text = SharedTextModels.GetSample(),
            Name = "sasa",
            Slug = "saa"

        };
    }

    public static CreateCharacterDto GetSampleCreateDto()
    {
        return new CreateCharacterDto()
        {
            TextId = Guid.NewGuid(),
            Name = "sasa",
            Slug = "saa"
        };
    }

    public static Character GetSampleForUpdate()
    {
        return new Character()
        {
            Name = "sasasasa",
            Slug = "sssasasaa",
            Text = SharedTextModels.GetSampleForUpdate()
        };
    }

    public static UpdateCharacterDto GetSampleUpdateDto()
    {
        return new UpdateCharacterDto()
        {
            TextId = Guid.NewGuid(),
            Name="_#p1",
            Slug="1232"
        };
    }
}