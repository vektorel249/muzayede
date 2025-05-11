using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Domain.Commands;
using Vektorel.Muzayede.Modules.Domain.Queries;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProposalsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProposalsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActiveProposals(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetActiveProposalsRequest(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("closed")]
    public async Task<IActionResult> GetMyProposals(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetActiveProposalsRequest(), cancellationToken);
        return Ok(result);
    }

    [HttpPost("make")]
    public async Task<IActionResult> MakeProposal([FromBody]MakeProposalRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok();
    }
}