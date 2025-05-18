namespace Vektorel.Muzayede.Admin.Helpers;

public class UserAgentMiddleware
{
    private readonly RequestDelegate next;

    public UserAgentMiddleware(RequestDelegate request)
    {
        this.next = request;
    }

    public Task Invoke(HttpContext httpContext, UserAgentInfo userAgent)
    {
        userAgent.Ip = httpContext.Connection.RemoteIpAddress?.ToString();
        userAgent.UserAgent = httpContext.Request.Headers["User-Agent"].ToString();

        return next(httpContext);
    }
}
