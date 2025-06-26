using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booxer.WebAPI.Constants;
using Booxer.Application.Modules.Reservations.Create;
using Booxer.Application.Modules.Reservations.FindMany;
using Booxer.Application.Modules.Reservations.Delete;

namespace Booxer.WebAPI.Controllers;

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