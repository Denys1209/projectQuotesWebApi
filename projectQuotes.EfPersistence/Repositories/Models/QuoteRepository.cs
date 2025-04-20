using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class QuoteRepository : CrudRepository<Quote>, IQuoteRepository
{
    public QuoteRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}

