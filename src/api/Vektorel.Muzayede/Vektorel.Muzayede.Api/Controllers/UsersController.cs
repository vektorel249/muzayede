using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator mediator;

    public UsersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        await Task.CompletedTask;
        return Ok("liste boş");
    }
}
