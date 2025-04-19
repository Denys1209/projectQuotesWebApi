using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;

namespace projectQuotes.UnitTests.Repositories.CrudRepositories;

public class ActRepositoryTest : SharedRepositoryTest<Act, UpdateActDto, CreateActDto, ActRepository, SharedActModels>
{
    public ActRepositoryTest()
    {
    }

    protected override ActRepository GetRepository(AppDbContext appDbContext)
    {
        return new ActRepository(appDbContext);
    }



}
