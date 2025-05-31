using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Domain.Queries.Statistics;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class StatisticsController : ControllerBase
{
    private readonly IMediator mediator;

    public StatisticsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("active-products")]
    public async Task<IActionResult> GetActiveProductCount(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetActiveProductCountRequest(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("daily-proposals")]
    public async Task<IActionResult> GetDailyProposalCount(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetDailyProposalCountRequest(), cancellationToken);
        return Ok(result);
    }
}
