using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotesWebApi.Application.Services.Relations.FavoriteQuotes;
using projectQuotesWebApi.Shared.RelationController;

namespace projectQuotesWebApi.Controllers.Relations;

public class FavoriteQuoteRelationControllera(IFavoriteQuoteRelationService relationService, IHttpContextAccessor httpContextAccessor) :
    RelationController<FavoriteQuote, User, Quote, IFavoriteQuoteRelationService>(relationService, httpContextAccessor);
