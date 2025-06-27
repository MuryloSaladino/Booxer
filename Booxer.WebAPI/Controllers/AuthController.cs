using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booxer.WebAPI.Constants;
using Booxer.Application.Commands.Auth.Login;
using Booxer.Application.Commands.Auth.ReadSelfDetails;
using Booxer.Application.Commands.Auth.Logout;

namespace Booxer.WebAPI.Controllers;

[ApiController, Route(APIRoutes.Auth)]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost, Route("login")]
    public async Task<ActionResult> Login(
        LoginRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpGet, Route("user")]
    public async Task<ActionResult<ReadSelfDetailsResponse>> ReadSelfDetails(
        [FromQuery] ReadSelfDetailsRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("logout")]
    public async Task<ActionResult> Logout(
        [FromQuery] LogoutRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return NoContent();
    }
}