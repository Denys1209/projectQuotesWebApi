using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Texts;

public interface ITextService : ICrudService<GetTextDto, CreateTextDto, UpdateTextDto, Text, GetTextDto>;
