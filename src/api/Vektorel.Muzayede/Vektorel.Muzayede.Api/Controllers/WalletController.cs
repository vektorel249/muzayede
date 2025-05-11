using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Vektorel.Muzayede.Api.Controllers
{
    [ApiController  ]
    [Route("[controller]")]
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
            var result = await mediator.Send(new GetWalletBalance(), cancellationToken);
            return Ok(result);
        }

    }
}
