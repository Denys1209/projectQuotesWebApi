using projectQuotes.Infrastructure.Filtering.Transforms;

namespace projectQuotes.Infrastructure.Filtering;

public static partial class Filtering
{
    private static IFilteringTransform[] Transforms { get; } = [];
}