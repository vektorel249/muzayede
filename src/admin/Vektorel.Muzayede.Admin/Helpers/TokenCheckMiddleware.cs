using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using Vektorel.Muzayede.Common.Helpers;
using Vektorel.Muzayede.DistributedCache;

namespace Vektorel.Muzayede.Admin.Helpers;

public class TokenCheckMiddleware
{
    private readonly RequestDelegate next;

    public TokenCheckMiddleware(RequestDelegate request)
    {
        this.next = request;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var endpoint = httpContext.GetEndpoint();

        if (endpoint is null)
        {
            await next(httpContext);
            return;
        }

        var allowedForAnoymous = endpoint.Metadata.GetMetadata<IAllowAnonymous>();
        if (allowedForAnoymous is not null)
        {
            await next(httpContext);
            return;
        }
        var idCookie = httpContext.Request.Cookies["mzyd-id"];
        if (idCookie is null)
        {
            httpContext.Response.StatusCode = HttpStatusCode.Redirect.GetHashCode();
            httpContext.Response.Redirect("/Authentication/SignIn", true);
            return;
        }

        var redisService = httpContext.RequestServices.GetRequiredService<RedisService>();
        var userAgentInfo = httpContext.RequestServices.GetRequiredService<UserAgentInfo>();
        var id = Encoding.UTF8.GetString(Convert.FromBase64String(idCookie));
        var key = userAgentInfo.GetKey(Guid.Parse(id));
        var token = await redisService.GetStringAsync(key);
        if (token is not null)
        {
            userAgentInfo.Token = token;
            await next(httpContext);
            return;
        }

        httpContext.Response.StatusCode = HttpStatusCode.Redirect.GetHashCode();
        httpContext.Response.Redirect("/Authentication/SignIn", true);
    }
}

public class UserAgentInfo
{
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public string Token { get; set; }

    public string GetKey(Guid userId)
    {
        return AuthenticationHelper.CreateHash(userId, $"{Ip}-{UserAgent}");
    }
}