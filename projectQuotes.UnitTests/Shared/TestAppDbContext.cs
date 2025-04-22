using Microsoft.EntityFrameworkCore;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.EfPersistence.Data;
using projectQuotes.UnitTests.Shared.TestModels;

namespace projectQuotes.UnitTests.Shared;

public class TestAppDbContext : AppDbContext
{
    public TestAppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Approach 1: ONLY ignore the navigation properties
        modelBuilder.Entity<Quote>()
            .Ignore(q => q.Creator);

        modelBuilder.Entity<User>()
            .Ignore(u => u.CreatedQuotes);

        // Configure only the foreign key itself
        modelBuilder.Entity<Quote>()
            .Property(q => q.CreatorId)
            .IsRequired();

        modelBuilder.Ignore<Quote>();
        //modelBuilder.Entity<TestQuote>().ToTable("Quotes");
    }
}