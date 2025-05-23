using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Users.Commands;
using Vektorel.Muzayede.Modules.Users.Queries;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthenticationController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest request, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("update-password")]
    [Authorize]
    public async Task<IActionResult> UpdatePassword()
    {
        await Task.CompletedTask;
        return Ok("değiştirildi");
    }
}