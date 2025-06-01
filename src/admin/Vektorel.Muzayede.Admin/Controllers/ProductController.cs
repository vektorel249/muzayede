using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Admin.Helpers;
using Vektorel.Muzayede.Admin.Models.Products;
using Vektorel.Muzayede.Common.Dtos;

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

    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        var boards = await api.Get<ApiResult<List<OptionItem>>>("api/boards/options", cancellationToken);

        //TODO: EV ÖDEVİ
        var product = await api.Get<ProductViewModel>("api/products/detail/" + id, cancellationToken);
        if (product == null)
        {
            return RedirectToAction("Index");
        }

        var model = new UpdateProductViewModel
        {
            Id = id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };
        return View(model);
    }

    public async Task<IActionResult> UpdateProduct(UpdateProductViewModel model, CancellationToken cancellationToken)
    {
        var result = await api.Post<UpdateProductViewModel, ApiResult<bool>>("api/products/update", model, cancellationToken);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }

        ViewBag.Message = result.Message;
        return View(model);
    }
}
