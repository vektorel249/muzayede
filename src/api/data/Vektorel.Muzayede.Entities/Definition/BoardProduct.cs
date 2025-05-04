using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vektorel.Muzayede.Entities.Definition;

[Table("BoardProducts", Schema = "Definition")]
public class BoardProduct : EntityBase
{
    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public Guid BoardId { get; set; }

    public int Order { get; set; }
    public DateTime? AtBoardUntil { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }

    [ForeignKey(nameof(BoardId))]
    public Board Board { get; set; }
}
