using Microsoft.EntityFrameworkCore.Metadata;

namespace projectQuotes.Infrastructure.Filtering.Transforms;

public interface IFilteringTransform
{
    IEnumerable<IEnumerable<FilteringItem>> Transform(IEntityType entityType,
        IEnumerable<IEnumerable<FilteringItem>> items);
}