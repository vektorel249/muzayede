namespace Vektorel.Muzayede.Admin.Models.Products;

public class ProductListViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid? BoardId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}