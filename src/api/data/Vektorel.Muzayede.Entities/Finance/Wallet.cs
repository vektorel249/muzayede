using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vektorel.Muzayede.Entities.Identity;

namespace Vektorel.Muzayede.Entities.Finance;

[Table("Wallets", Schema = "Finance")]
public class Wallet : EntityBase
{
    [MaxLength(16)]
    public string Label { get; set; }
    public Guid UserId { get; set; }
    public decimal Balance { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}
