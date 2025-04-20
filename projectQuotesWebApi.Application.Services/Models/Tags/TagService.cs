using AutoMapper;
using projectQuotes.Application.Repositories.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Charcters;
using projectQuotes.Dtos.Dto.Models.Tags;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.Tags;

public class TagService : CrudService<GetTagDto, CreateTagDto, UpdateTagDto, Tag, GetTagDto, ITagRepository>, ITagService
{
    private readonly ITextRepository textRepository;
    public TagService(ITagRepository repository, ITextRepository textRepository, IMapper mapper) : base(repository, mapper)
    {
        this.textRepository = textRepository;
    }
    public override async Task<Guid> CreateAsync(CreateTagDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Tag>(createDto);

        if (createDto.TextId is not null)
        {
            model.Text = await textRepository.GetAsync((Guid)createDto.TextId, cancellationToken);
        }

        return await Repository.AddAsync(model, cancellationToken);
    }

    public override async Task UpdateAsync(UpdateTagDto updateTagDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<Tag>(updateTagDto);

        if (updateTagDto.TextId is not null)
        {
            model.Text = await textRepository.GetAsync((Guid)updateTagDto.TextId, cancellationToken);
        }

        await Repository.UpdateAsync(model, cancellationToken);
    }
}
