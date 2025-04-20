using projectQuotes.Application.Repositories.Shared;
using projectQuotes.Domain.Models.Enteties;

namespace projectQuotes.Application.Repositories.Models;

public interface IQuoteRepository : ICrudRepository<Quote>;
