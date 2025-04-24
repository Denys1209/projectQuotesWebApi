using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotes.Dtos.Shared;
using projectQuotesWebApi.Application.Services.Models.Quotes;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class QuoteController: CrudController<GetQuoteDto, UpdateQuoteDto, CreateQuoteDto, IQuoteService, Quote, GetQuoteDto>
{
    public QuoteController(IQuoteService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }


    [HttpPost("GetAll")]
    [AllowAnonymous]
    public override async Task<IActionResult> GetAll([FromBody] FilterPaginationDto paginationDto,
        CancellationToken cancellationToken)
    {

        return await base.GetAll(paginationDto, cancellationToken);
    }
}
