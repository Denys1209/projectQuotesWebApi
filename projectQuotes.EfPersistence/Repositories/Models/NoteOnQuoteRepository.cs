using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class NoteOnQuoteRepository : CrudRepository<NoteOnQuote>, INoteOnQuoteRepository
{
    public NoteOnQuoteRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
