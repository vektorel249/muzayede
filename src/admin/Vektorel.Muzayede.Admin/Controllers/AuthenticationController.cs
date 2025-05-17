using Microsoft.AspNetCore.Mvc;
using Vektorel.Muzayede.Admin.Helpers;
using Vektorel.Muzayede.Admin.Models.Authentications;

namespace Vektorel.Muzayede.Admin.Controllers;

public class AuthenticationController : Controller
{
    private readonly MuzayedeApiClient api;

    public AuthenticationController(MuzayedeApiClient api)
    {
        this.api = api;
    }
    public IActionResult SignIn()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUpUser(RegisterViewModel model, CancellationToken cancellationToken)
    {
        var result = await api.Post("api/authentication/sign-up", model, cancellationToken);
        return View();
    }
}
