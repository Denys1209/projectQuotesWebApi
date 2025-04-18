using System.Text.Json.Serialization;

namespace projectQuotes.Domain.ForSort;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortOrder
{
    Asc,
    Desc
}