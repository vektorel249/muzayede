using System.Security.Claims;
using Vektorel.Muzayede.Common.Enums;
using Vektorel.Muzayede.Common.Helpers;

namespace Vektorel.Muzayede.Api.Middlewares;

public class CurrentUserControlMiddleware
{
    private readonly RequestDelegate next;

    public CurrentUserControlMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public Task InvokeAsync(HttpContext context)
    {
        var currentUserInfo = context.RequestServices.GetRequiredService<CurrentUserInfo>();

        var claims = context.User.Claims;
        if (claims.Any())
        {
            currentUserInfo.UserId = Guid.Parse(claims.First(f => f.Type == ClaimTypes.NameIdentifier).Value);
            currentUserInfo.Mail = claims.First(f => f.Type == ClaimTypes.Email).Value;
            currentUserInfo.UserType = Enum.Parse<UserType>(claims.First(f => f.Type == ClaimTypes.GroupSid).Value);
        }

        return next(context);
    }
}
