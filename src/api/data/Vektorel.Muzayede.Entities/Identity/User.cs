using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vektorel.Muzayede.Common.Enums;

namespace Vektorel.Muzayede.Entities.Identity;

[Table("Users", Schema = "Identity")]
public class User : EntityBase
{
    [MaxLength(64)]
    public string Mail { get; set; }
    [MaxLength(64)]
    public string Password { get; set; }
    [MaxLength(64)]
    public string Code { get; set; }
    [MaxLength(32)]
    public string DisplayName { get; set; }
    public UserType UserType { get; set; }
}
