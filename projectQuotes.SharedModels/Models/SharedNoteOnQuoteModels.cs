using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.NoteOnQuotes;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Models.NoteOnQuotes;

namespace projectQuotes.SharedModels.Models;

public class SharedNoteOnQuoteModels : SharedModelsBase, IShareModels<CreateNoteOnQuoteDto, UpdateNoteOnQuoteDto, NoteOnQuote>
{
    public static void AddAllDependencies(IServiceCollection services)
    {
        SharedUserModels.AddAllDependencies(services);
        SharedQuoteModels.AddAllDependencies(services);
        services.AddScoped<INoteOnQuoteRepository, NoteOnQuoteRepository>();
        services.AddScoped<INoteOnQuoteService, NoteOnQuoteService>();

    }

    public static async Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
    {
        var dto = SharedNoteOnQuoteModels.GetSampleCreateDto();

        dto.CreatorId = await SharedUserModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);
        dto.QuoteId = await SharedQuoteModels.CreateModelWithAllDependenciesAsync(serviceProvider, cancellationToken);

        return await serviceProvider.GetService<INoteOnQuoteService>().CreateAsync(dto, cancellationToken);
    }

    public static NoteOnQuote GetSample()
    {
        return new NoteOnQuote()
        {
            Quote = SharedQuoteModels.GetSample(),
            Text = "sasa",
            Creator = SharedUserModels.GetSample(),
            IsPublished = false,

        };
    }

    public static CreateNoteOnQuoteDto GetSampleCreateDto()
    {
        return new CreateNoteOnQuoteDto()
        {
            QuoteId = Guid.NewGuid(),
            Text = "121",
            CreatorId = Guid.NewGuid(),
            IsPublished = false,
        };
    }

    public static NoteOnQuote GetSampleForUpdate()
    {
        return new NoteOnQuote()
        {
            Quote = SharedQuoteModels.GetSampleForUpdate(),
            Text ="aa",
            Creator = SharedUserModels.GetSampleForUpdate(),
            IsPublished = true,
            
        };
    }

    public static UpdateNoteOnQuoteDto GetSampleUpdateDto()
    {
        return new UpdateNoteOnQuoteDto()
        {
            QuoteId = Guid.NewGuid(),
            Text="cs",
            CreatorId= Guid.NewGuid(),
            IsPublished = true,
        };
    }
}