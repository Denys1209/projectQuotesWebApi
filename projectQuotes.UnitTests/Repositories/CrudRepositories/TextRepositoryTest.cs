using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;

namespace projectQuotes.UnitTests.Repositories.CrudRepositories;

public class TextRepositoryTest : SharedRepositoryTest<Text, UpdateTextDto, CreateTextDto, TextRepository, SharedTextModels>
{
    public TextRepositoryTest()
    {
    }

    protected override TextRepository GetRepository(AppDbContext appDbContext)
    {
        return new TextRepository(appDbContext); 
    }



   }
