using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.Tags;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class TagServiceTest: SharedServiceTest<
    GetTagDto,
    CreateTagDto,
    UpdateTagDto,
    Tag,
    GetTagDto,
    TagRepository,
    TagService,
    SharedTagModels>
{
    protected override TagService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();

        return new TagService(builder.GetRequiredService<ITagRepository>(), builder.GetRequiredService<ITextRepository>(), Mapper);
    }
}
