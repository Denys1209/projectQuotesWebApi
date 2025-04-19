using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotesWebApi.Application.Services.Models.Acts;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class ActController : CrudController<GetActDto, UpdateActDto, CreateActDto, IActService, Act, GetActDto>
{
    public ActController(IActService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}
