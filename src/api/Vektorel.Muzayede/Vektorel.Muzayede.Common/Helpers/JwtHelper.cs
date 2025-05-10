using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Vektorel.Muzayede.Common.Enums;
using Vektorel.Muzayede.Common.Options;

namespace Vektorel.Muzayede.Common.Helpers;

public class JwtHelper
{
    public static (string Token, DateTime ExpiresAt) GenerateToken(Guid id, string mail, UserType type, JwtOptions options)
    {
        var expiresAt = DateTime.Now.AddMinutes(options.ExpireMinute);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, mail),
                new Claim(ClaimTypes.GroupSid, type.GetHashCode().ToString())
            }),
            Expires = expiresAt,
            SigningCredentials = credentials,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenResult = tokenHandler.WriteToken(token);

        return (tokenResult, expiresAt);
    }
}
