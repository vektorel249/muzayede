using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vektorel.Muzayede.Admin.Models;

namespace Vektorel.Muzayede.Admin.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}