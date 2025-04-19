using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace projectQuotes.Domain.Models.Enteties;

public class Scene : Model
{
    [Range(SceneConstants.MinNumber, SceneConstants.MaxNumber)]
    public required int Number { get; set; }

    [StringLength(SceneConstants.MaxWholeText)]
    public required string WholeText { get; set; }

    public required virtual Act Act { get; set; }
        
}
