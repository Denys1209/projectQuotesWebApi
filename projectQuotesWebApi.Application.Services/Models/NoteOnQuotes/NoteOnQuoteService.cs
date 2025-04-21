using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Application.Repositories.Users;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.NoteOnQuotes;
using projectQuotes.Dtos.Dto.Models.Quotes;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.NoteOnQuotes;

public class NoteOnQuoteService : CrudService<GetNoteOnQuoteDto, CreateNoteOnQuoteDto, UpdateNoteOnQuoteDto, NoteOnQuote, GetNoteOnQuoteDto, INoteOnQuoteRepository>, INoteOnQuoteService
{

    protected readonly IQuoteRepository quoteRepository;

    protected readonly IUserRepository userRepository;

    public NoteOnQuoteService(INoteOnQuoteRepository repository, IQuoteRepository quoteRepository, IUserRepository userRepository , IMapper mapper) : base(repository, mapper)
    {
        this.quoteRepository = quoteRepository;
        this.userRepository = userRepository;
    }

    public override async Task<Guid> CreateAsync(CreateNoteOnQuoteDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<NoteOnQuote>(createDto);

        model.Creator = await userRepository.GetAsync(createDto.CreatorId, cancellationToken);
        model.Quote = await quoteRepository.GetAsync(createDto.QuoteId, cancellationToken);



        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateNoteOnQuoteDto updateQuoteDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<NoteOnQuote>(updateQuoteDto);

        model.Creator = await userRepository.GetAsync(updateQuoteDto.CreatorId, cancellationToken);
        model.Quote = await quoteRepository.GetAsync(updateQuoteDto.QuoteId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }
}
