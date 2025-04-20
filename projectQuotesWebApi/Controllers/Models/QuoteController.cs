using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotesWebApi.Application.Services.Models.Quotes;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class QuoteController: CrudController<GetQuoteDto, UpdateQuoteDto, CreateQuoteDto, IQuoteService, Quote, GetQuoteDto>
{
    public QuoteController(IQuoteService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}
