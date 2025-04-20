using Anytour.IntegrationTests.shared;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotes.Dtos.Shared;
using projectQuotes.SharedModels.Models;
using projectQuotesWebApi.Application.Services.Models.Tags;
using projectQuotesWebApi.Controllers.Models;
using System.Formats.Asn1;

namespace projectQuotes.IntegrationTests.Controllers.CrudControllers;

public class TagControllerTest: BaseCrudControllerTest<GetTagDto, UpdateTagDto, CreateTagDto, ITagService, Tag, GetTagDto, ReturnPageDto<GetTagDto>, TagController, SharedTagModels>
{
    public TagControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedTagModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<TagController> GetController(IServiceProvider alternativeServices)
    {
        return new TagController(alternativeServices.GetRequiredService<ITagService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override async Task MutationBeforeDtoCreation(CreateTagDto createDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.TextId = textId;
    }

    protected override async Task MutationBeforeDtoUpdate(UpdateTagDto updateDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.TextId = textId;
    }


}