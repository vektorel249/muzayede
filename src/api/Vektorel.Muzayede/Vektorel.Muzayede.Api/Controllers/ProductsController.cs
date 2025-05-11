using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Domain.Queries.Products;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetProducts([FromQuery]int page, [FromQuery]int count, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetPagedProductsRequest(page, count), cancellationToken);
        return Ok(result);
    }
}