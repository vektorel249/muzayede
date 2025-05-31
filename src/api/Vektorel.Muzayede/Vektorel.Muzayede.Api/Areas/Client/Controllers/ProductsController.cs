using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Domain.Queries.Products;

namespace Vektorel.Muzayede.Api.Areas.Client.Controllers;

[ApiController]
[Route("api/client/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("latest")]
    public async Task<IActionResult> GetLatest(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetLatestProductsRequest(), cancellationToken);
        return Ok(result);
    }
}
