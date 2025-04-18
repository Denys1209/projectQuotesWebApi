using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectQuotesWebApi.Shared;

namespace projectQuotesWebApi.Controllers;

public class HealthController : MyBaseController
{
    public HealthController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
    }

    [HttpGet("check")]
    [AllowAnonymous]
    public IActionResult Get(CancellationToken cancellationToken) => Ok();

}
