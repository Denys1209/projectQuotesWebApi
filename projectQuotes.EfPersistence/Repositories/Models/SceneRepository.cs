using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class SceneRepository : CrudRepository<Scene>, ISceneRepository
{
    public SceneRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
