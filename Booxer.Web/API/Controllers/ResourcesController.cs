using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booxer.Web.API.Constants;
using Booxer.Application.Commands.Resources.Create;
using Booxer.Application.Commands.Resources.FindMany;
using Booxer.Application.Commands.Resources.FindOne;

namespace Booxer.Web.API.Controllers;

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

    [HttpGet, Route("{resourceId}")]
    public async Task<ActionResult<List<FindOneResourceResponse>>> FindOne(
        [FromRoute] Guid resourceId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindOneResourceRequest(resourceId), cancellationToken);
        return Ok(response);
    }
}