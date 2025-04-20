using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotesWebApi.Application.Services.Relations.TagQuotes;
using projectQuotesWebApi.Shared.RelationController;

namespace projectQuotesWebApi.Controllers.Relations;

public class TagQuoteRelationController(ITagQuoteRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<TagQuote, Tag, Quote, ITagQuoteRelationService>(relationService, httpContextAccessor);
