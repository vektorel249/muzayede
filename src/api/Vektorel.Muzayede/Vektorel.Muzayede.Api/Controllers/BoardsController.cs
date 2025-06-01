using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Domain.Queries.Boards;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardsController : ControllerBase
{
    private readonly IMediator mediator;

    public BoardsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("options")]
    public async Task<IActionResult> GetBoardsAsOptions(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new BoardsAsOptionsRequest(), cancellationToken);
        return Ok(result);
    }
}
