using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class AuthorRepository : CrudRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
