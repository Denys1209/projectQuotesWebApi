using projectQuotes.Application.Repositories.Relations;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Relations;

public class FavoriteQuoteRelationRepository : RelationRepository<FavoriteQuote, User, Quote>, IFavoriteQuoteRelationRepository
{
    public FavoriteQuoteRelationRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
