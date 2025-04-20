using projectQuotes.Application.Repositories.Models;
using projectQuotes.Application.Repositories.Relations;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.EfPersistence.Repositories.Relations;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;

namespace projectQuotes.UnitTests.Repositories.RelationRepositories;

public class TagQuoteRelationRepositoryTest : SharedRelationRepositoryTest<TagQuote, Tag, Quote, ITagQuoteRelationRepository, ITagRepository, IQuoteRepository>
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
        return new TagQuote()
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override ITagQuoteRelationRepository GetRelationRepository(AppDbContext appDbContext)
    {
        return new TagQuoteRelationRepository(appDbContext);
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
