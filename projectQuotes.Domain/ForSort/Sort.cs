using projectQuotes.Constants.Shared;

namespace projectQuotes.Domain.ForSort;
public sealed record Sort(
    string Column = SharedStringConstants.IdName,
    SortOrder SortOrder = SortOrder.Asc);