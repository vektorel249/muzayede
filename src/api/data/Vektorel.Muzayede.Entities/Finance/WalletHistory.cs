using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vektorel.Muzayede.Common.Enums;

namespace Vektorel.Muzayede.Entities.Finance;

[Table("WalletHistory", Schema = "Finance")]
public class WalletHistory : EntityBase
{
    [Required]
    public Guid WalletId { get; set; }

    public decimal Amount { get; set; }
    public WalletActionType Type { get; set; }
}
