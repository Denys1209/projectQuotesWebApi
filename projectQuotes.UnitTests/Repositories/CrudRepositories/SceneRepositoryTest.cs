using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;

namespace projectQuotes.UnitTests.Repositories.CrudRepositories;

public class SceneRepositoryTest : SharedRepositoryTest<Scene, UpdateSceneDto, CreateSceneDto, SceneRepository, SharedSceneModels>
{
    public SceneRepositoryTest()
    {
    }

    protected override SceneRepository GetRepository(AppDbContext appDbContext)
    {
        return new SceneRepository(appDbContext); 
    }

   }
