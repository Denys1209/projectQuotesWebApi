using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Texts;

public class TextService : CrudService<GetTextDto, CreateTextDto, UpdateTextDto, Text, GetTextDto, ITextRepository>, ITextService
{
    private readonly IAuthorRepository authorRepository;

    public TextService(ITextRepository repository, IAuthorRepository authorRepository, IMapper mapper) : base(repository, mapper)
    {
        this.authorRepository = authorRepository;
    }

    public override async Task<Guid> CreateAsync(CreateTextDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Text>(createDto);

        model.Author = await authorRepository.GetAsync(createDto.AuthorId, cancellationToken);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateTextDto updateTextDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Text>(updateTextDto);

        model.Author = await authorRepository.GetAsync(updateTextDto.AuthorId, cancellationToken);

        await Repository.UpdateAsync(model, cancellationToken);
    }
}
