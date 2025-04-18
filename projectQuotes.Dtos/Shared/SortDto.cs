using projectQuotes.Constants.Shared;
using projectQuotes.Domain.ForSort;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Shared;

[ExportTsInterface]
public class SortDto
{
    [DefaultValue(SharedStringConstants.IdName)]
    [TsDefaultValue(SharedStringConstants.IdName)]
    public string Column { get; set; } = SharedStringConstants.IdName;

    [DefaultValue(SortOrder.Asc)] public SortOrder SortOrder { get; set; } = SortOrder.Asc;
}