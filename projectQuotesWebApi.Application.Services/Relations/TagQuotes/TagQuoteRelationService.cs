using projectQuotes.Application.Repositories.Relations;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotesWebApi.Application.Services.Shared.Relation;

namespace projectQuotesWebApi.Application.Services.Relations.TagQuotes;

public class TagQuoteRelationService : RelationService<TagQuote, Tag, Quote, ITagQuoteRelationRepository>, ITagQuoteRelationService
{
    public TagQuoteRelationService(ITagQuoteRelationRepository relationRepository) : base(relationRepository)
    {
    }
}
