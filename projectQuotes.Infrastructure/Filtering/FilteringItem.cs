using Microsoft.EntityFrameworkCore.Metadata;

namespace projectQuotes.Infrastructure.Filtering;

public record FilteringItem(
    string ReadableName,
    string ActualName,
    IPropertyBase Property
);