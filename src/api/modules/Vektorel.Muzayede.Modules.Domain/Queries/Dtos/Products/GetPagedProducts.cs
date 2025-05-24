namespace Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Products;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Price { get; internal set; }
}
