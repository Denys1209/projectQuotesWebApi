﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Shared;
using projectQuotes.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Domain.Models.Relations;

namespace projectQuotes.EfPersistence.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
  
    public DbSet<Author> Authors { get; set; }

    public DbSet<Text> Texts { get; set; }

    public DbSet<Act> Acts { get; set; }

    public DbSet<Scene> Scenes { get; set; }

    public DbSet<Character> Characters { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Quote> Quotes { get; set; }

    public DbSet<TagQuote> TagQuotes { get; set; }

    public DbSet<NoteOnQuote> NoteOnQuotes { get; set; }

    public DbSet<FavoriteQuote> FavoriteQuotes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole<Guid>>().HasData(
            new IdentityRole<Guid>
            {
                Id = Guid.Parse("2ae998d7-d8b1-4616-a0b3-60d29eca6c90"),
                Name = UserConstants.AdminRole,
                NormalizedName = UserConstants.AdminRole.ToUpper()
            },
            new IdentityRole<Guid>
            {
                Id = Guid.Parse("b1e76313-b130-44f8-ae76-6aff097064aa"),
                Name = UserConstants.UserRole,
                NormalizedName = UserConstants.UserRole.ToUpper()
            }
        );

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasOne(q => q.Creator)
                  .WithMany(u => u.CreatedQuotes)
                  .HasForeignKey(q => q.CreatorId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Make sure this property is mapped correctly
            entity.Property(q => q.CreatorId);
        });

        // Relations
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                     .Where(e => e.ClrType.GenericIsSubclassOf(typeof(RelationModel<,>))))
        {
            var relationType = entityType.ClrType.GetSubclassType(typeof(RelationModel<,>))!;
            var firstType = relationType.GetGenericArguments()[0];
            var secondType = relationType.GetGenericArguments()[1];

            var firstName = firstType.Name;
            var secondName = firstType == secondType ? $"Second{secondType.Name}" : secondType.Name;

            var firstIdName = $"{firstName}Id";
            var secondIdName = $"{secondName}Id";

            modelBuilder.Entity(entityType.ClrType).Property("FirstId").HasColumnName(firstIdName);
            modelBuilder.Entity(entityType.ClrType).Property("SecondId").HasColumnName(secondIdName);
        }

        //User
        modelBuilder.Entity<User>()
            .HasMany(e => e.Roles)
            .WithMany()
            .UsingEntity<IdentityUserRole<Guid>>();

     
        //Quotes
        modelBuilder.Entity<Quote>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Quotes)
            .UsingEntity<TagQuote>();

        modelBuilder.Entity<Quote>()
            .HasMany(e => e.InFavoriteQuotes)
            .WithMany(e => e.FavoriteQuotes)
            .UsingEntity<FavoriteQuote>();

       
    }
}