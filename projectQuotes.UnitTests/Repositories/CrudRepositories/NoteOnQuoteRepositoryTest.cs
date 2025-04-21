using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.NoteOnQuotes;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Repositories.Models;
using projectQuotes.SharedModels.Models;
using projectQuotes.UnitTests.Shared.Repositories;

namespace projectQuotes.UnitTests.Repositories.CrudRepositories;

public class NoteOnQuoteRepositoryTest : SharedRepositoryTest<NoteOnQuote, UpdateNoteOnQuoteDto, CreateNoteOnQuoteDto, NoteOnQuoteRepository, SharedNoteOnQuoteModels>
{
    public NoteOnQuoteRepositoryTest()
    {
    }

    protected override NoteOnQuoteRepository GetRepository(AppDbContext appDbContext)
    {
        return new NoteOnQuoteRepository(appDbContext);
    }



}
