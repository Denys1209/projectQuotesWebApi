using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Scenes;

public interface ISceneService : ICrudService<GetSceneDto, CreateSceneDto, UpdateSceneDto, Scene, GetLightSceneDto> 
{

}

