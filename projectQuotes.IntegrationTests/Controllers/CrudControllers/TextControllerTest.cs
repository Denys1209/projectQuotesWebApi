using Anytour.IntegrationTests.shared;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Shared;
using projectQuotes.SharedModels.Models;
using projectQuotesWebApi.Application.Services.Models.Authors;
using projectQuotesWebApi.Application.Services.Models.Texts;
using projectQuotesWebApi.Controllers.Models;

namespace projectQuotes.IntegrationTests.Controllers.CrudControllers;

public class TextControllerTest : BaseCrudControllerTest<GetTextDto, UpdateTextDto, CreateTextDto, ITextService, Text, GetTextDto, ReturnPageDto<GetTextDto>, TextController>
{
    public TextControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedTextModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<TextController> GetController(IServiceProvider alternativeServices)
    {
        return new TextController(alternativeServices.GetRequiredService<ITextService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override async Task MutationBeforeDtoCreation(CreateTextDto createDto, IServiceProvider alternativeServices)
    {
        var authorId = await alternativeServices.GetRequiredService<IAuthorService>().CreateAsync(SharedAuthorModels.GetSampleCreateDto(), CancellationToken);
        createDto.AuthorId = authorId;
    }

    protected override async Task MutationBeforeDtoUpdate(UpdateTextDto updateDto, IServiceProvider alternativeServices)
    {
        var authorId = await alternativeServices.GetRequiredService<IAuthorService>().CreateAsync(SharedAuthorModels.GetSampleCreateDto(), CancellationToken);
        updateDto.AuthorId = authorId;
    }

    protected override CreateTextDto GetCreateDtoSample()
    {
        return SharedTextModels.GetSampleCreateDto();
    }


    protected override Text GetModelSample()
    {
        return SharedTextModels.GetSample();
    }

    protected override UpdateTextDto GetUpdateDtoSample()
    {
        return SharedTextModels.GetSampleUpdateDto();
    }
}

