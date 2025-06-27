using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booxer.WebAPI.Constants;
using Booxer.Application.Commands.Users.Create;
using Booxer.Application.Commands.Users.FindOne;
using Booxer.Application.Commands.Users.FindMany;

namespace Booxer.WebAPI.Controllers;

[ApiController, Route(APIRoutes.Users)]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(
        CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Users, response);
    }

    [HttpGet, Route("{userId}")]
    public async Task<ActionResult<FindOneUserResponse>> FindOne(
        [FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new FindOneUserRequest(userId), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindManyUsersResponse>>> FindMany(
        [FromQuery] FindManyUsersRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}