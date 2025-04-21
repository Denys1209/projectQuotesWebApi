using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.NoteOnQuotes;
using projectQuotesWebApi.Application.Services.Models.NoteOnQuotes;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers.Models;

public class NoteOnQuoteContoller: CrudController<GetNoteOnQuoteDto, UpdateNoteOnQuoteDto, CreateNoteOnQuoteDto, INoteOnQuoteService, NoteOnQuote, GetNoteOnQuoteDto>
{
    public NoteOnQuoteContoller(INoteOnQuoteService crudService, IHttpContextAccessor httpContextAccessor) : base(crudService, httpContextAccessor)
    {
    }
}
