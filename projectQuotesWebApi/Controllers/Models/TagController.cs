using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotes.Dtos.Shared;
using projectQuotesWebApi.Application.Services.Models.Tags;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class TagController: CrudController<GetTagDto, UpdateTagDto, CreateTagDto, ITagService, Tag, GetTagDto>
{
    public TagController(ITagService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
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