using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotesWebApi.Application.Services.Models.Authors;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class AuthorController : CrudController<GetAuthorDto, UpdateAuthorDto, CreateAuthorDto, IAuthorService, Author, GetAuthorDto>
{
    public AuthorController(IAuthorService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}
