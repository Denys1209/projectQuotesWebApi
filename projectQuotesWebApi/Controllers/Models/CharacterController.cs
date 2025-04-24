using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotes.Dtos.Shared;
using projectQuotesWebApi.Application.Services.Models.Chracters;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class CharacterController : CrudController<GetCharacterDto, UpdateCharacterDto, CreateCharacterDto, ICharacterService, Character, GetCharacterDto>
{
    public CharacterController(ICharacterService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
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
