using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Users.Queries;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthenticationController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody]SignInRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("update-password")]
    [Authorize]
    public async Task<IActionResult> UpdatePassword()
    {
        await Task.CompletedTask;
        return Ok("deðiþtirildi");
    }
}


[ApiController]
[Route("controller")]
public class ProposalsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProposalsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyProposals()
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpPost("make")]
    public async Task<IActionResult> MakeProposal()
    {
        await Task.CompletedTask;
        return Ok();
    }
}