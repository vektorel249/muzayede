﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Domain.Commands.Products;
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

    [HttpGet("get-selected")]
    public async Task<IActionResult> GetSelectedProduct([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetSelectedProductRequest(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}