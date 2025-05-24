using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Vektorel.Muzayede.Admin.Helpers;

public class CustomCookieAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public CustomCookieAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var idCookie = Request.Cookies["mzyd-id"];
        if (idCookie is null)
        {
            return Task.FromResult(AuthenticateResult.Fail("No authorization"));
        }
        var id = Encoding.UTF8.GetString(Convert.FromBase64String(idCookie));

        if(!Guid.TryParse(id, out var userId))
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid authorization"));
        }

        var claims = new[] { new Claim(ClaimTypes.NameIdentifier, id) };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}