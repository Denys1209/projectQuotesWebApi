using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Shared;
using projectQuotesWebApi.Application.Services.Models.Texts;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class TextController : CrudController<GetTextDto, UpdateTextDto, CreateTextDto, ITextService, Text, GetTextDto>
{
    public TextController(ITextService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
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
