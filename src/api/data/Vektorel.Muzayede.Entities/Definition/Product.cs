using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vektorel.Muzayede.Entities.Identity;

namespace Vektorel.Muzayede.Entities.Definition;

[Table("Products", Schema = "Definition")]
public class Product : EntityBase
{
    [Required]
    [MaxLength(64)]
    public string Name { get; set; }
    [MaxLength(512)]
    public string Description { get; set; }
    [Required]
    public decimal CurrentPrice { get; set; }
    public Guid OwnerId { get; set; }

    [ForeignKey(nameof(OwnerId))]
    public User Owner { get; set; }
}