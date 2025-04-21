using projectQuotes.Application.Repositories.Shared.Relation;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;

namespace projectQuotes.Application.Repositories.Relations;

public interface IFavoriteQuoteRelationRepository : IRelationRepository<FavoriteQuote, User, Quote>
{
}
