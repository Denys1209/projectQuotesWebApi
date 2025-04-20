using projectQuotes.Application.Repositories.Models;
using projectQuotes.Application.Repositories.Shared;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class TagRepository : CrudRepository<Tag>, ITagRepository
{
    public TagRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
