using projectQuotes.Constants.Models;
using projectQuotes.Domain.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace projectQuotes.Domain.Models.Enteties;

public class Act : Model
{
    [Range(ActConstants.MinNumber, ActConstants.MaxNumber)]
    public required int Number { get; set; } 

    public required virtual Text Text { get; set; }

    public  virtual ICollection<Scene> Scenes { get; set; } = new HashSet<Scene>();
}
