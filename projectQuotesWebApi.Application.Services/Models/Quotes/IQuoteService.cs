using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Quotes;

public interface IQuoteService : ICrudService<GetQuoteDto, CreateQuoteDto, UpdateQuoteDto, Quote, GetQuoteDto>;
