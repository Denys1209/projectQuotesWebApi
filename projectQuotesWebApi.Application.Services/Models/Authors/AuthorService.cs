using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Authors;

public class AuthorService : CrudService<GetAuthorDto, CreateAuthorDto, UpdateAuthorDto, Author, GetAuthorDto, IAuthorRepository>, IAuthorService
{
    public AuthorService(IAuthorRepository relationRepository, IMapper mapper) : base(relationRepository, mapper)
    {
    }
}
