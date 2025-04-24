using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using IModel = projectQuotes.Domain.Models.Shared.IModel;
using projectQuotes.EfPersistence.Data;
using projectQuotes.EfPersistence.Extensions;
using projectQuotes.Application.Repositories.Shared;
using projectQuotes.Domain.ForFilter;
using projectQuotes.Domain.ForSort;
using projectQuotes.Infrastructure.Filtering;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Application.Repositories.Models;

namespace projectQuotes.EfPersistence.Repositories.Models;

public class QuoteRepository : CrudRepository<Quote>, IQuoteRepository
{
    public QuoteRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<PaginatedCollection<Quote>> GetAllAsync(FilterPagination dto,
       CancellationToken cancellationToken)
    {
        var skip = (dto.PageNumber - 1) * dto.PageSize;
        var take = dto.PageSize;

        var query = DbContext.Set<Quote>().AsQueryable();

        foreach (var i in dto.Filters)
        {
            foreach (var j in i)
            {
                if (j.Column == "Text.Id")
                {
                    query = query.Where(e => e.Text.Id.ToString() == j.SearchTerm);
                    dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                }

                if (j.Column == "Tags.Slug")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.Tags.FirstOrDefault(item => item.Slug == j.SearchTerm) != null);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }
                if (j.Column == "Character.Slug")
                {
                    if (j.FilterType == FilterType.Strict)
                    {
                        query = query.Where(e => e.Character.Slug == j.SearchTerm);
                        dto.Filters = dto.Filters.Select(filter => filter.Where(item => item != j).ToList()).ToList();
                    }
                }
            }

            dto.Filters = dto.Filters.Where(filter => filter.Count() > 0).ToList();

        }


        query = dto.Filters.Aggregate(query,
            (current, filter) => Filter(current, filter));
        var totalItems = await query.CountAsync(cancellationToken);

        var firstSort = dto.Sorts.FirstOrDefault();
        var otherSorts = dto.Sorts.Skip(1).ToArray();
        if (firstSort != null)
        {
            var orderedQuery = Sort(query, firstSort.Column, firstSort.SortOrder == SortOrder.Asc);
            query = otherSorts.Aggregate(orderedQuery,
                (current, sort) => ThenSort(current, sort.Column, sort.SortOrder == SortOrder.Asc));
        }

        var models = await query.Skip(skip).Take(take).ToListAsync(cancellationToken);


        int howManyPages = (int)Math.Ceiling((decimal)totalItems / dto.PageSize);

        bool isNextPage = howManyPages > dto.PageNumber - 1 ? true : false;
        bool isPreviosPage = dto.PageNumber - 1 > 0 ? true : false;

        return new PaginatedCollection<Quote>(
            models,
            totalItems,
            howManyPages,
            isNextPage,
            isPreviosPage
            );
    }
}

