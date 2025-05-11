using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vektorel.Muzayede.Entities.Definition;

[Table("Boards", Schema = "Definition")]
public class Board : EntityBase
{
    [Required]
    [MaxLength(32)]
    public string Title { get; set; }
}