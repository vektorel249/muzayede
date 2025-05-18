using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Vektorel.Muzayede.Admin.Helpers;
using Vektorel.Muzayede.Admin.Models.Authentications;
using Vektorel.Muzayede.DistributedCache;

namespace Vektorel.Muzayede.Admin.Controllers;

public class AuthenticationController : Controller
{
    private readonly MuzayedeApiClient api;
    private readonly RedisService redisService;
    private readonly UserAgentInfo userAgentInfo;

    public AuthenticationController(MuzayedeApiClient api, RedisService redisService, UserAgentInfo userAgentInfo)
    {
        this.api = api;
        this.redisService = redisService;
        this.userAgentInfo = userAgentInfo;
    }

    [AllowAnonymous]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignInUser(LoginViewModel model, CancellationToken cancellationToken)
    {
        var result = await api.Post<LoginViewModel, ApiResult<LoginResult>>("api/authentication/sign-in", model, cancellationToken);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = result.Data.ExpiresAt  
        };

        Response.Cookies.Append("mzyd-id", Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Data.Id.ToString())), cookieOptions);
        Response.Cookies.Append("mzyd-name", Convert.ToBase64String(Encoding.UTF8.GetBytes(result.Data.DisplayName)), cookieOptions);

        var key = userAgentInfo.GetKey(result.Data.Id);
        await redisService.SetStringAsync(key, result.Data.Token, TimeSpan.FromMinutes(30));

        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpUser(RegisterViewModel model, CancellationToken cancellationToken)
    {
        var result = await api.Post<RegisterViewModel, bool>("api/authentication/sign-up", model, cancellationToken);
        return Redirect(nameof(SignIn));
    }

    [AllowAnonymous]
    public IActionResult SignOutUser()
    {
        Response.Cookies.Delete("mzyd-id");
        Response.Cookies.Delete("mzyd-name");
        return RedirectToAction("SignIn", "Authentication");
    }
}
