using MediatR;
using Microsoft.AspNetCore.Mvc;
using Booxer.Web.API.Constants;
using Booxer.Application.Commands.Categories.Create;
using Booxer.Application.Commands.Categories.FindMany;

namespace Booxer.Web.API.Controllers;

[ApiController, Route(APIRoutes.Categories)]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateCategoryResponse>> Create(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Created(APIRoutes.Categories, response);
    }

    [HttpGet]
    public async Task<ActionResult<List<FindManyCategoriesResponse>>> FindMany(
        [FromQuery] FindManyCategoriesRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}