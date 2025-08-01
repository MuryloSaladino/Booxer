using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booxer.Web.API.Constants;
using Booxer.Application.Commands.Reservations.Create;
using Booxer.Application.Commands.Reservations.FindMany;
using Booxer.Application.Commands.Reservations.Delete;

namespace Booxer.Web.API.Controllers;

[ApiController, Route(APIRoutes.Reservations)]
public class ReservationsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateReservationResponse>> Create(
        CreateReservationRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Reservations, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindManyReservationsResponse>>> FindMany(
        [FromQuery] FindManyReservationsRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete, Route("{reservationId}")]
    public async Task<ActionResult> Delete(
        [FromRoute] Guid reservationId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteReservationRequest(reservationId), cancellationToken);
        return NoContent();
    }
}