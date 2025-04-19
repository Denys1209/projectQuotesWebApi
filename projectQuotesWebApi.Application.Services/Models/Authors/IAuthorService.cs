using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Authors;

public interface IAuthorService : ICrudService<GetAuthorDto, CreateAuthorDto, UpdateAuthorDto, Author, GetAuthorDto>
{
}
