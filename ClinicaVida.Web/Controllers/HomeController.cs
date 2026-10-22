using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClinicaVida.Web.Models;

namespace ClinicaVida.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    // Controllers/HomeController.cs
   public IActionResult Sobre()
    {
    return View();       // Views/Home/Sobre.cshtml
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
