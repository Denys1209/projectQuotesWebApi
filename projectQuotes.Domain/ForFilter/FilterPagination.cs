using projectQuotes.Constants.Shared;
using projectQuotes.Domain.ForSort;

namespace projectQuotes.Domain.ForFilter;

public sealed record FilterPagination(
    int PageNumber = SharedNumberConstatnts.DefaultPageToStartWith,
    int PageSize = SharedNumberConstatnts.DefaultItemsInOnePage)
{
    public IEnumerable<IEnumerable<Filter>> Filters { get; set; } = [];
    public IEnumerable<Sort> Sorts { get; init; } = [];
}
