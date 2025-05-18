using System.Text.Json.Serialization;

namespace Vektorel.Muzayede.Admin.Models.Authentications;

public class LoginViewModel
{
    public string Password { get; set; }
    public string Mail { get; set; }
}


public class LoginResult
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}