using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotesWebApi.Application.Services.Shared.Relation;

namespace projectQuotesWebApi.Application.Services.Relations.TagQuotes;

public interface ITagQuoteRelationService : IRelationService<TagQuote, Tag, Quote>;
