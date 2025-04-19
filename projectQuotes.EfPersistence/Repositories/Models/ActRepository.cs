using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class ActRepository : CrudRepository<Act>, IActRepository
{
    public ActRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
