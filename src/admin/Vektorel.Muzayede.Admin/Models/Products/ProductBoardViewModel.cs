using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vektorel.Muzayede.Admin.Models.Products;

public class ProductBoardViewModel
{
    public Guid ProductId { get; set; }
    public Guid? BoardId { get; set; }
    public List<SelectListItem> Boards { get; set; }
}