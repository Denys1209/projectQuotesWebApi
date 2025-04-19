using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace projectQuotes.UnitTests.Repositories.CrudRepositories;

public class AuthorRepositoryTest : SharedRepositoryTest<Author, UpdateAuthorDto, CreateAuthorDto, AuthorRepository, SharedAuthorModels>
{
    public AuthorRepositoryTest()
    {
    }

    protected override AuthorRepository GetRepository(AppDbContext appDbContext)
    {
        return new AuthorRepository(appDbContext); 
    }



   }
