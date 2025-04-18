﻿using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Shared;

[ExportTsInterface]
public class ReturnPageDto<T>
{
    public required IReadOnlyCollection<T> Models { get; set; }
    public required int HowManyPages { get; set; }

    public required int Total { get; set; }

    public required bool IsNextPage { get; set; }
    public required bool IsPreviosPage { get; set; }
}