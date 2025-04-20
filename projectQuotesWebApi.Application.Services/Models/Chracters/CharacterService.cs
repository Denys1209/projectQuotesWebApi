using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Chracters;

public class CharacterService : CrudService<GetCharacterDto, CreateCharacterDto, UpdateCharacterDto, Character, GetCharacterDto, ICharacterRepository>, ICharacterService
{

    private readonly ITextRepository textRepository;
    public CharacterService(ICharacterRepository repository, ITextRepository textRepository, IMapper mapper) : base(repository, mapper)
    {
        this.textRepository = textRepository;
    }
    public override async Task<Guid> CreateAsync(CreateCharacterDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Character>(createDto);

        model.Text = await textRepository.GetAsync(createDto.TextId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateCharacterDto updateCharacterDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Character>(updateCharacterDto);

        model.Text = await textRepository.GetAsync(updateCharacterDto.TextId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }
}
