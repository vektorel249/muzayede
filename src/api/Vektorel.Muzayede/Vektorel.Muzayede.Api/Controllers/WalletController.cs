using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Modules.Domain.Queries.Wallets;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController  ]
[Route("api/[controller]")]
public class WalletController : ControllerBase
{
    private readonly IMediator mediator;

    public WalletController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("test")]
    public async Task<IActionResult> GetWalletBalance()
    {
        await Task.CompletedTask;
        return Ok("değiştirildi");
    }

    [HttpGet("balance")]
    public async Task<IActionResult> GetBalance(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetWalletBalanceRequest(), cancellationToken);
        return Ok(result);
    }

}
