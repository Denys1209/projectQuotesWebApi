using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;

namespace projectQuotes.UnitTests.Repositories.CrudRepositories;

public class TagRepositoryTest : SharedRepositoryTest<Tag, UpdateTagDto, CreateTagDto, TagRepository, SharedTagModels>
{
    public TagRepositoryTest()
    {
    }

    protected override TagRepository GetRepository(AppDbContext appDbContext)
    {
        return new TagRepository(appDbContext);
    }



}