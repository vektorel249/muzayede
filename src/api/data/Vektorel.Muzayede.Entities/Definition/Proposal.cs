using System.ComponentModel.DataAnnotations.Schema;
using Vektorel.Muzayede.Entities.Identity;

namespace Vektorel.Muzayede.Entities.Definition;

[Table("Proposals", Schema = "Definition")]
public class Proposal : EntityBase
{
    public Guid BoardProductId { get; set; }
    public string UserId { get; set; }
    public decimal Amount { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    [ForeignKey(nameof(BoardProductId))]
    public BoardProduct BoardProduct { get; set; }
}