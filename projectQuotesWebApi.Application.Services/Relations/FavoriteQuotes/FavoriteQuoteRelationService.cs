using projectQuotes.Application.Repositories.Relations;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotesWebApi.Application.Services.Shared.Relation;

namespace projectQuotesWebApi.Application.Services.Relations.FavoriteQuotes;

public class FavoriteQuoteRelationService : RelationService<FavoriteQuote, User, Quote, IFavoriteQuoteRelationRepository>, IFavoriteQuoteRelationService
{
    public FavoriteQuoteRelationService(IFavoriteQuoteRelationRepository relationRepository) : base(relationRepository)
    {

    }
}
