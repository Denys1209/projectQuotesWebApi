using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotesWebApi.Application.Services.Models.Scenes;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class SceneController : CrudController<GetSceneDto, UpdateSceneDto, CreateSceneDto, ISceneService, Scene, GetLightSceneDto>
{
    public SceneController(ISceneService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}
