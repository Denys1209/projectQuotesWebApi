using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotesWebApi.Application.Services.Models.Tags;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class TagController: CrudController<GetTagDto, UpdateTagDto, CreateTagDto, ITagService, Tag, GetTagDto>
{
    public TagController(ITagService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}