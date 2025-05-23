using projectQuotes.Constants.Shared;
using projectQuotes.Domain.ForFilter;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Shared;

[ExportTsInterface]
public class FilterDto
{
    [DefaultValue("")]
    [TsDefaultValue("")]
    public string SearchTerm { get; set; } = "";

    [DefaultValue(SharedStringConstants.IdName)]
    [TsDefaultValue(SharedStringConstants.IdName)]
    public string Column { get; set; } = SharedStringConstants.IdName;

    [DefaultValue(FilterType.Strict)]
    public FilterType FilterType { get; set; } = FilterType.Strict;

    [DefaultValue(false)] public bool Negate { get; set; } = false;
}