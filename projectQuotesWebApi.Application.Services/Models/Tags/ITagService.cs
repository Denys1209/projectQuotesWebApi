using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Tags;

public interface ITagService : ICrudService<GetTagDto, CreateTagDto, UpdateTagDto, Tag, GetTagDto>;
