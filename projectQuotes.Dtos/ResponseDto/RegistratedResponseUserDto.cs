﻿using projectQuotes.Dtos.Shared;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.ResponseDto;

[ExportTsInterface]
public class RegistratedResponseUserDto : ModelDto
{
    public required string Message { get; set; }

    public required string JwtToken { get; set; }
}