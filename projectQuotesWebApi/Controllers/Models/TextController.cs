using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotesWebApi.Application.Services.Models.Texts;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class TextController : CrudController<GetTextDto, UpdateTextDto, CreateTextDto, ITextService, Text, GetTextDto>
{
    public TextController(ITextService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}
