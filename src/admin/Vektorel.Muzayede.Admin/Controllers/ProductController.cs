using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Admin.Helpers;
using Vektorel.Muzayede.Admin.Models.Products;

namespace Vektorel.Muzayede.Admin.Controllers;

[Authorize]
public class ProductController : Controller
{
    private readonly MuzayedeApiClient api;

    public ProductController(MuzayedeApiClient api)
    {
        this.api = api;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await api.Get<ApiResult<List<ProductListViewModel>>>("api/products/all?count=10&page=1", cancellationToken);
        if (result.Succeeded)
        {
            return View(result.Data);
        }
        ViewBag.Message = result.Message;
        return View(null);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductViewModel model, CancellationToken cancellationToken)
    {
        var result = await api.Post<CreateProductViewModel, ApiResult<bool>>("api/products/create", model, cancellationToken);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }

        ViewBag.Message = result.Message;
        return View(model);
    }

    public IActionResult Edit(Guid id)
    {
        return View();
    }
}
