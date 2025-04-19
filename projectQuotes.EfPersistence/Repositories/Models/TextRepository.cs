using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class TextRepository : CrudRepository<Text>, ITextRepository
{
    public TextRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
