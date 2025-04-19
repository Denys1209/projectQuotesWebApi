using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Scenes;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Scenes;

public class SceneService : CrudService<GetSceneDto, CreateSceneDto, UpdateSceneDto, Scene, GetLightSceneDto, ISceneRepository>, ISceneService
{
    private readonly IActRepository actRepository;
    public SceneService(ISceneRepository repository, IActRepository actRepository, IMapper mapper) : base(repository, mapper)
    {
        this.actRepository = actRepository;
    }
    public override async Task<Guid> CreateAsync(CreateSceneDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Scene>(createDto);

        model.Act = await actRepository.GetAsync(createDto.ActId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateSceneDto updateSceneDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Scene>(updateSceneDto);

        model.Act = await actRepository.GetAsync(updateSceneDto.ActId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }
}
