namespace Vektorel.Muzayede.Modules.Domain.Queries.Dtos.Products;

public class DetailedProductDto
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public List<ProductCommentViewDto> Comments { get; set; }
    public List<ProductProposalViewDto> Proposals { get; set; }
}

public class ProductCommentViewDto
{
    public string User { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Comment { get; set; }
}

public class ProductProposalViewDto
{
    public string DisplayName { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
}