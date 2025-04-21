using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.Quotes;

namespace projectQuotes.SharedModels.Models;

public class SharedQuoteModels : SharedModelsBase, IShareModels<CreateQuoteDto, UpdateQuoteDto, Quote>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedTextModels.AddAllDependencies(services);
        SharedUserModels.AddAllDependencies(services);
        SharedCharacterModels.AddAllDependencies(services);
        SharedTagModels.AddAllDependencies(services);
        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IQuoteService, QuoteService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedQuoteModels.GetSampleCreateDto();

        dto.TextId = await SharedTextModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        dto.CreatorId = await SharedUserModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        dto.CharacterId = await SharedCharacterModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        dto.TagIds = [await SharedTagModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken)];

        return await serviceProvider.GetService<IQuoteService>().CreateAsync(dto, cancellationToken);
    }

    public static Quote GetSample()
    {
        return new Quote()
        {
            Text = SharedTextModels.GetSample(),
            Character = SharedCharacterModels.GetSample(),
            Context = "sas",
            Creator = SharedUserModels.GetSample(),
            Description = "sas",
            QuoteText = "sasa",
            Tags = [],
            IsPublished = false,

        };
    }

    public static CreateQuoteDto GetSampleCreateDto()
    {
        return new CreateQuoteDto()
        {
            TextId = Guid.NewGuid(),
            CharacterId = Guid.NewGuid(),
            Context = "sasas",
            CreatorId = Guid.NewGuid(),
            Description = "sasa",
            QuoteText = "sasa",
            TagIds = [Guid.NewGuid()],
            IsPublished = false,
        };
    }

    public static Quote GetSampleForUpdate()
    {
        return new Quote()
        {
            Text = SharedTextModels.GetSampleForUpdate(),
            Character = SharedCharacterModels.GetSampleForUpdate(),
            Context = "sasasa",
            Creator = SharedUserModels.GetSampleForUpdate(),
            Description = "sasa",
            QuoteText = "sasa",
            Tags= [],
            IsPublished = true,
            
        };
    }

    public static UpdateQuoteDto GetSampleUpdateDto()
    {
        return new UpdateQuoteDto()
        {
            TextId = Guid.NewGuid(),
            CharacterId = Guid.NewGuid(),
            Context = "sasasa2121" ,
            CreatorId= Guid.NewGuid(),
            Description = "3223",
            QuoteText = "2121",
            TagIds= [Guid.NewGuid()],
            IsPublished = true,
        };
    }
}