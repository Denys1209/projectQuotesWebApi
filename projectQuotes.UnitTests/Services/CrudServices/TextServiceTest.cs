using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.Texts;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class TextServiceTest : SharedServiceTest<
    GetTextDto,
    CreateTextDto,
    UpdateTextDto,
    Text,
    GetTextDto,
    TextRepository,
    TextService,
    SharedTextModels>
{
    protected override TextService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new TextService(builder.GetRequiredService<ITextRepository>(), builder.GetRequiredService<IAuthorRepository>(), Mapper);
    }
}
