using Microsoft.AspNetCore.Mvc;

namespace projectQuotesWebApi.Shared.RelationController;

public interface IRelationController
{
    public Task<IActionResult> Create([FromRoute] Guid firstId, [FromRoute] Guid secondId,
        CancellationToken cancellationToken);

    public Task<IActionResult> Delete([FromRoute] Guid firstId, [FromRoute] Guid secondId,
        CancellationToken cancellationToken);
}