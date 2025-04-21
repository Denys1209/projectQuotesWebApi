using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.NoteOnQuotes;
using projectQuotesWebApi.Application.Services.Shared;

namespace projectQuotesWebApi.Application.Services.Models.NoteOnQuotes;

public interface INoteOnQuoteService : ICrudService<GetNoteOnQuoteDto, CreateNoteOnQuoteDto, UpdateNoteOnQuoteDto, NoteOnQuote, GetNoteOnQuoteDto>;
