namespace projectQuotes.Dtos.Shared;

public class ModelDtoWithTimeStamp : ModelDto
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
