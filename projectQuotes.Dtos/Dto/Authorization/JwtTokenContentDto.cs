﻿using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Dto.Authorization;

[ExportTsInterface]
public record JwtTokenContentDto
{
    public required string? Email;
    public required string? Id;
    public required string? Role;
}