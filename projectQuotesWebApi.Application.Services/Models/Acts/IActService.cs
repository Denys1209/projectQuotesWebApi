using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Acts;

public interface IActService : ICrudService<GetActDto, CreateActDto, UpdateActDto, Act, GetActDto>;
