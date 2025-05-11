namespace Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Products;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
public record GetPagedProducts(List<ProductDto> products);
