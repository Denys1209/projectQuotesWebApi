using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Application.Repositories.Users;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.Quotes;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class QuoteServiceTest: SharedServiceTest<
GetQuoteDto,
CreateQuoteDto,
UpdateQuoteDto,
Quote,
GetQuoteDto,
QuoteRepository,
QuoteService,
SharedQuoteModels>
{
    protected override QuoteService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new QuoteService(builder.GetRequiredService<IQuoteRepository>(), builder.GetRequiredService<IUserRepository>(), builder.GetRequiredService<ICharacterRepository>(), builder.GetRequiredService<ITextRepository>(), Mapper);
    }
  protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        var db = GetDatabaseContext();
        alternativeServices.AddSingleton(db);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(GetUserManager(db));

        alternativeServices.AddSingleton(GetRoleManager(db));


        SharedQuoteModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }


}
