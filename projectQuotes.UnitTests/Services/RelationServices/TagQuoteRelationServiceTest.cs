using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.EfPersistence.Repositories.Relations;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Relations.TagQuotes;
using System.Diagnostics.CodeAnalysis;

namespace projectQuotes.UnitTests.Services.RelationServices;

public class TagQuoteRelationServiceTest : SharedRelationServiceTest<TagQuote, TagQuoteRelationService, Tag, Quote, ITagRepository, IQuoteRepository>
{
    public override Tag GetFirstModel()
    {
        return SharedTagModels.GetSample();
    }

    public override ITagRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new TagRepository(appDbContext);
    }

    public override TagQuote GetRelationModel(Guid firstId, Guid secondId)
    {
        return new TagQuote
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override TagQuoteRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new TagQuoteRelationService(new TagQuoteRelationRepository(appDbContext));
    }

    public override Quote GetSecondModel()
    {
        return SharedQuoteModels.GetSample();
    }

    public override IQuoteRepository GetSecondRepository(AppDbContext appDbContext)
    {
        return new QuoteRepository(appDbContext);
    }
}
