using Anytour.IntegrationTests.shared;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotes.Dtos.Shared;
using projectQuotes.SharedModels.Models;
using projectQuotesWebApi.Application.Services.Models.Quotes;
using projectQuotesWebApi.Controllers.Models;

namespace projectQuotes.IntegrationTests.Controllers.CrudControllers;

//public class QuoteControllerTest: BaseCrudControllerTest<GetQuoteDto, UpdateQuoteDto, CreateQuoteDto, IQuoteService, Quote, GetQuoteDto, ReturnPageDto<GetQuoteDto>, QuoteController, SharedQuoteModels>
//{
//    public QuoteControllerTest(IntegrationTestWebAppFactory factory) : base(factory)
//    {
//    }

//    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
//    {

//        alternativeServices.AddSingleton(AppDbContext);

//        alternativeServices.AddSingleton(Mapper);

//        alternativeServices.AddSingleton(UserManager);

//        alternativeServices.AddSingleton(RoleManager);

//        SharedQuoteModels.AddAllDependencies(alternativeServices);

//        return alternativeServices;
//    }

//    protected override async Task<QuoteController> GetController(IServiceProvider alternativeServices)
//    {
//        return new QuoteController(alternativeServices.GetRequiredService<IQuoteService>(), await GetHttpContextAccessForAdminUser(GetUserManager(AppDbContext), GetRoleManager(AppDbContext)));
//    }

//    protected override async Task MutationBeforeDtoCreation(CreateQuoteDto createDto, IServiceProvider alternativeServices)
//    {
//        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        var characterId = await SharedCharacterModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        var creatorId = await SharedUserModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        createDto.TextId = textId;
//        createDto.CharacterId = characterId;
//        createDto.CreatorId = creatorId;
//    }

//    protected override async Task MutationBeforeDtoUpdate(UpdateQuoteDto updateDto, IServiceProvider alternativeServices)
//    {
//        var textId = await SharedTextModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        var characterId = await SharedCharacterModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        var creatorId = await SharedUserModels.CreateModelWithAllDependenciesAsync(alternativeServices, CancellationToken);
//        updateDto.TextId = textId;
//        updateDto.CreatorId = characterId;
//        updateDto.CreatorId = creatorId;
//    }


//}