namespace Vektorel.Muzayede.Admin.Models.Products;

public class ProductListViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}