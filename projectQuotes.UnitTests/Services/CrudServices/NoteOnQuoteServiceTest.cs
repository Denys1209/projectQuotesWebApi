using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Application.Repositories.Users;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.NoteOnQuotes;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Models.NoteOnQuotes;

namespace projectQuotes.UnitTests.Services.CrudServices;

public class NoteOnQuoteServiceTest : SharedServiceTest<
    GetNoteOnQuoteDto,
    CreateNoteOnQuoteDto,
    UpdateNoteOnQuoteDto,
    NoteOnQuote,
    GetNoteOnQuoteDto,
    NoteOnQuoteRepository,
    NoteOnQuoteService,
    SharedNoteOnQuoteModels>
{
    protected override NoteOnQuoteService GetService(IServiceCollection alternativeServices)
    {
        var builder = alternativeServices.BuildServiceProvider();



        return new NoteOnQuoteService(builder.GetRequiredService<INoteOnQuoteRepository>(), builder.GetRequiredService<IQuoteRepository>(), builder.GetRequiredService<IUserRepository>(), Mapper);
    }

    protected override IServiceCollection GetAllServices(IServiceCollection alternativeServices)
    {
        var db = GetDatabaseContext();
        alternativeServices.AddSingleton(db);

        alternativeServices.AddSingleton(Mapper);

        alternativeServices.AddSingleton(GetUserManager(db));

        alternativeServices.AddSingleton(GetRoleManager(db));


        SharedNoteOnQuoteModels.AddAllDependencies(alternativeServices);

        return alternativeServices;
    }
}
