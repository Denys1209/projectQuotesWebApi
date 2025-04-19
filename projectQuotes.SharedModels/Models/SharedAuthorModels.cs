using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.Authors;
using System.Diagnostics.CodeAnalysis;

namespace projectQuotes.SharedModels.Models;

public class SharedAuthorModels : SharedModelsBase, IShareModels<CreateAuthorDto, UpdateAuthorDto, Author>

{
    public static void AddAllDependencies(IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IAuthorService, AuthorService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedAuthorModels.GetSampleCreateDto();

        return await serviceProvider.GetService<IAuthorService>().CreateAsync(dto, cancellationToken);
    }

    public static Author GetSample()
    {
        return new Author()
        {
            Name = "name",
        };
    }

    public static CreateAuthorDto GetSampleCreateDto()
    {
        return new CreateAuthorDto()
        {
            Name = "sdads",
        };
    }

    public static Author GetSampleForUpdate()
    {
        return new Author()
        {
            Name = "name32",
        };
    }

    public static UpdateAuthorDto GetSampleUpdateDto()
    {
        return new UpdateAuthorDto()
        {
            Name = "sasa",
        };
    }
}
