using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;
using projectQuotesWebApi.Application.Services.Shared.Relation;

namespace projectQuotesWebApi.Application.Services.Relations.FavoriteQuotes;

public interface IFavoriteQuoteRelationService : IRelationService<FavoriteQuote, User, Quote>;
