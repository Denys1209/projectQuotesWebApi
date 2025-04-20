using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotesWebApi.Application.Services.Models.Chracters;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class CharacterController : CrudController<GetCharacterDto, UpdateCharacterDto, CreateCharacterDto, ICharacterService, Character, GetCharacterDto>
{
    public CharacterController(ICharacterService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}
