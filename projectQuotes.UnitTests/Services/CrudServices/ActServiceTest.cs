using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.Acts;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class ActServiceTest: SharedServiceTest<
    GetActDto,
    CreateActDto,
    UpdateActDto,
    Act,
    GetActDto,
    ActRepository,
    ActService,
    SharedActModels>
{
    protected override ActService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new ActService(builder.GetRequiredService<IActRepository>(), builder.GetRequiredService<ITextRepository>(), Mapper);
    }
}
