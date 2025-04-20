using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Chracters;

public interface ICharacterService : ICrudService<GetCharacterDto, CreateCharacterDto, UpdateCharacterDto, Character, GetCharacterDto>;
