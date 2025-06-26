using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booxer.WebAPI.Constants;
using Booxer.Application.Modules.Resources.Create;
using Booxer.Application.Modules.Resources.FindMany;

namespace Booxer.WebAPI.Controllers;

[ApiController, Route(APIRoutes.Resources)]
public class ResourcesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateResourceResponse>> Create(
        CreateResourceRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Resources, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindManyResourcesResponse>>> FindMany(
        [FromQuery] FindManyResourcesRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}