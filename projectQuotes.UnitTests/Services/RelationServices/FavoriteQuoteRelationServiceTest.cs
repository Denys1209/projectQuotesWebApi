using projectQuotes.Application.Repositories.Models;
using projectQuotes.Application.Repositories.Users;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.EfPersistence.Repositories.Relations;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Services;
using projectQuotesWebApi.Application.Services.Relations.FavoriteQuotes;

namespace projectQuotes.UnitTests.Services.RelationServices;

public class FavoriteQuoteRelationServiceTest : SharedRelationServiceTest<FavoriteQuote, FavoriteQuoteRelationService, User, Quote, IUserRepository, IQuoteRepository>
{
    public override User GetFirstModel()
    {
        return SharedUserModels.GetSample();
    }

    public override IUserRepository GetFirstRepository(AppDbContext appDbContext)
    {
        return new UserRepository(appDbContext, GetUserManager(appDbContext));
    }

    public override FavoriteQuote GetRelationModel(Guid firstId, Guid secondId)
    {
        return new FavoriteQuote
        {
            FirstId = firstId,
            SecondId = secondId
        };
    }

    public override FavoriteQuoteRelationService GetRelationService(AppDbContext appDbContext)
    {
        return new FavoriteQuoteRelationService(new FavoriteQuoteRelationRepository(appDbContext));
    }

    public override Quote GetSecondModel()
    {
        return SharedQuoteModels.GetSample();
    }

    public override IQuoteRepository GetSecondRepository(AppDbContext appDbContext)
    {
        return new QuoteRepository(appDbContext);
    }
}