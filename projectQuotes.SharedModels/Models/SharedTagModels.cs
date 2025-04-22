using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.Tags;

namespace projectQuotes.SharedModels.Models;

public class SharedTagModels : SharedModelsBase, IShareModels<CreateTagDto, UpdateTagDto, Tag>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedTextModels.AddAllDependencies(services);
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ITagService, TagService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedTagModels.GetSampleCreateDto();

        dto.TextId = await SharedTextModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        return await serviceProvider.GetService<ITagService>().CreateAsync(dto, cancellationToken);
    }

    public static Tag GetSample()
    {
        return new Tag()
        {
            Text = SharedTextModels.GetSample(),
            Name = "sasa",
            Slug = "saa",
            Description = "sasa",
            Quotes = []
            

        };
    }

    public static CreateTagDto GetSampleCreateDto()
    {
        return new CreateTagDto()
        {
            TextId = Guid.NewGuid(),
            Name = "sasa",
            Slug = "saa",
            Description = "sasa",

        };
    }

    public static Tag GetSampleForUpdate()
    {
        return new Tag()
        {
            Name = "sasasasa",
            Slug = "sssasasaa",
            Description = "sa",
            Quotes = []
        };
    }

    public static UpdateTagDto GetSampleUpdateDto()
    {
        return new UpdateTagDto()
        {
            TextId = Guid.NewGuid(),
            Name="_#p1",
            Slug="1232",
            Description = "sasas"
            
        };
    }
}