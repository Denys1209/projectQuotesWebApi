namespace projectQuotes.Domain.Models.Shared;

public class ModelWithTimeStamp : Model
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

}
