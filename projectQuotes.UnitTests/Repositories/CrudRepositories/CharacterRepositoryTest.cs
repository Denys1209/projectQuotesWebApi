using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;

namespace projectQuotes.UnitTests.Repositories.CrudRepositories;

public class CharacterRepositoryTest : SharedRepositoryTest<Character, UpdateCharacterDto, CreateCharacterDto, CharacterRepository, SharedCharacterModels>
{
    public CharacterRepositoryTest()
    {
    }

    protected override CharacterRepository GetRepository(AppDbContext appDbContext)
    {
        return new CharacterRepository(appDbContext);
    }



}
