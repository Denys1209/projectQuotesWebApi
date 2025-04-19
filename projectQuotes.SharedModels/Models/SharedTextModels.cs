using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Enums;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.Texts;
using System.ComponentModel;

namespace projectQuotes.SharedModels.Models;

public class SharedTextModels : SharedModelsBase, IShareModels<CreateTextDto, UpdateTextDto, Text>

{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedAuthorModels.AddAllDependencies(services);
        services.AddScoped<ITextRepository, TextRepository>();
        services.AddScoped<ITextService, TextService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedTextModels.GetSampleCreateDto();

        return await serviceProvider.GetService<ITextService>().CreateAsync(dto, cancellationToken);
    }

    public static Text GetSample()
    {
        return new Text()
        {
            Name = "name",
            Summary = "sas",
            Type = TypeTextEnum.Poem,
            Author = SharedAuthorModels.GetSample()
        };
    }

    public static CreateTextDto GetSampleCreateDto()
    {
        return new CreateTextDto()
        {
            Name = "name",
            Summary = "sas",
            Type = TypeTextEnum.Poem,
            AuthorId = Guid.NewGuid(),
        };
    }

    public static Text GetSampleForUpdate()
    {
        return new Text()
        {
            Name = "name32",
            Summary = "sasa1213",
            Author = SharedAuthorModels.GetSampleForUpdate(),
            Type = TypeTextEnum.Play,
            
        };
    }

    public static UpdateTextDto GetSampleUpdateDto()
    {
        return new UpdateTextDto()
        {
            Name = "sasa",
            AuthorId = Guid.NewGuid(),
            Summary = "sas",
            Type = TypeTextEnum.Play
        };
    }
}
