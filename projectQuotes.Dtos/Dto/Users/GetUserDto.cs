﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;
using projectQuotes.Dtos.Shared;

namespace projectQuotes.Dtos.Dto.Users;

[ExportTsInterface]
public class GetUserDto : ModelDto
{
    public required string Email { get; set; }
    public required string[] Roles { get; set; }

    public required string UserName { get; set; }


}