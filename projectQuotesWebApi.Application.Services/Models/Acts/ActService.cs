using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Acts;

public class ActService : CrudService<GetActDto, CreateActDto, UpdateActDto, Act, GetActDto, IActRepository>, IActService
{

    private readonly ITextRepository textRepository;
    public ActService(IActRepository repository, ITextRepository textRepository, IMapper mapper) : base(repository, mapper)
    {
        this.textRepository = textRepository;
    }

    public override async Task<Guid> CreateAsync(CreateActDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Act>(createDto);

        model.Text = await textRepository.GetAsync(createDto.TextId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateActDto updateActDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Act>(updateActDto);

        model.Text = await textRepository.GetAsync(updateActDto.TextId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }
}
