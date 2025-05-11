using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vektorel.Muzayede.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task<IActionResult> GetProducts()
    {
        return Ok("ürün listesi boş");
    }
}