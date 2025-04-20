using projectQuotes.Application.Repositories.Relations;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Relations;

public class TagQuoteRelationRepository : RelationRepository<TagQuote, Tag, Quote>, ITagQuoteRelationRepository
{
    public TagQuoteRelationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
