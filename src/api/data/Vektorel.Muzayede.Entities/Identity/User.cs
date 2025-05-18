using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vektorel.Muzayede.Common.Enums;

namespace Vektorel.Muzayede.Entities.Identity;

[Table("Users", Schema = "Identity")]
public class User : IdentityUser
{
    public string DisplayName { get; set; }
    public UserType UserType { get; set; }
}
