using projectQuotes.Application.Repositories.Shared.Relation;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;

namespace projectQuotes.Application.Repositories.Relations;

public interface ITagQuoteRelationRepository : IRelationRepository<TagQuote, Tag, Quote>;
