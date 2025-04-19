using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.Authors;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class AuthorServiceTest : SharedServiceTest<
    GetAuthorDto,
    CreateAuthorDto,
    UpdateAuthorDto,
    Author,
    GetAuthorDto,
    AuthorRepository,
    AuthorService,
    SharedAuthorModels>
{
    protected override AuthorService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new AuthorService(builder.GetRequiredService<IAuthorRepository>(), Mapper);
    }
}
