using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vektorel.Muzayede.Entities.Definition;

[Table("ProductPrices", Schema = "Definition")]
public class ProductPrice : EntityBase
{
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    public decimal Price { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
}
