using NpgsqlTypes;
using System.Text.Json.Serialization;

namespace projectQuotes.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TypeTextEnum
{
    [PgName("Poem")] Poem,

    [PgName("Play")] Play,

}
