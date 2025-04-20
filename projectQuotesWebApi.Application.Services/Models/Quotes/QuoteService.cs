using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Application.Repositories.Users;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Quotes;

public class QuoteService : CrudService<GetQuoteDto, CreateQuoteDto, UpdateQuoteDto, Quote, GetQuoteDto, IQuoteRepository>, IQuoteService
{

    private readonly ITextRepository textRepository;

    private readonly IUserRepository userRepository;

    private readonly ICharacterRepository characterRepository;

    public QuoteService(IQuoteRepository repository, IUserRepository userRepository, ICharacterRepository characterRepository, ITextRepository textRepository, IMapper mapper) : base(repository, mapper)
    {
        this.textRepository = textRepository;
        this.userRepository = userRepository;
        this.characterRepository = characterRepository;
    }

   public override async Task<Guid> CreateAsync(CreateQuoteDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Quote>(createDto);

        model.Text = await textRepository.GetAsync(createDto.TextId, cancellationToken);
        model.Character = await characterRepository.GetAsync(createDto.CharacterId, cancellationToken);
        model.Creator = await userRepository.GetAsync(createDto.CreatorId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateQuoteDto updateQuoteDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Quote>(updateQuoteDto);

        model.Text = await textRepository.GetAsync(updateQuoteDto.TextId, cancellationToken);
        model.Character = await characterRepository.GetAsync(updateQuoteDto.CharacterId, cancellationToken);
        model.Creator = await userRepository.GetAsync(updateQuoteDto.CreatorId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }

}
