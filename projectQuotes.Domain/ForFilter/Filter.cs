using projectQuotes.Constants.Shared;

namespace projectQuotes.Domain.ForFilter;

public sealed record Filter(
    string SearchTerm = "",
    string Column = SharedStringConstants.IdName,
    FilterType FilterType = FilterType.Strict,
    bool Negate = false);