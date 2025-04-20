using Anytour.IntegrationTests.shared;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotes.Dtos.Shared;
using projectQuotes.SharedModels.Models;
using projectQuotesWebApi.Application.Services.Models.Chracters;
using projectQuotesWebApi.Controllers.Models;

namespace projectQuotes.IntegrationTests.Controllers.CrudControllers;

public class CharacterControllerTest : BaseCrudControllerTest<GetCharacterDto, UpdateCharacterDto, CreateCharacterDto, ICharacterService, Character, GetCharacterDto, ReturnPageDto<GetCharacterDto>, CharacterController, SharedCharacterModels>
{
    public CharacterControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
    {
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {

        alternativeServices.AddSingleton(AppDbContext);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(UserManager);

        alternativeServices.AddSingleton(RoleManager);

        SharedCharacterModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }

    protected override async Task<CharacterController> GetController(IServiceProvider alternativeServices)
    {
        return new CharacterController(alternativeServices.GetRequiredService<ICharacterService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
    }

    protected override async Task MutationBeforeDtoCreation(CreateCharacterDto createDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        createDto.TextId = textId;
    }

    protected override async Task MutationBeforeDtoUpdate(UpdateCharacterDto updateDto, IServiceProvider alternativeServices)
    {
        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
        updateDto.TextId = textId;
    }


}

