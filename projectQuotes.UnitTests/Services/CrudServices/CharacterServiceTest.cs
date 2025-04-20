using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.Chracters;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class CharacterServiceTest: SharedServiceTest<
    GetCharacterDto,
    CreateCharacterDto,
    UpdateCharacterDto,
    Character,
    GetCharacterDto,
    CharacterRepository,
    CharacterService,
    SharedCharacterModels>
{
    protected override CharacterService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new CharacterService(builder.GetRequiredService<ICharacterRepository>(), builder.GetRequiredService<ITextRepository>(), Mapper);
    }
}
