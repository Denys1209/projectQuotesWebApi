﻿using projectQuotes.Constants.Controller;
using System.ComponentModel.DataAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace projectQuotes.Dtos.Shared;

[ExportTsInterface]
public abstract class ModelDto
{

    [Required(ErrorMessage = ControllerStringConstants.IdIsRequiredErrorMessage)]
    public virtual Guid Id { get; set; }
}