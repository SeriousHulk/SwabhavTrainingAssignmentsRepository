using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using welcome_mvc_core_app.Models;

namespace welcome_mvc_core_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public IActionResult Index()
    {
        ViewBag.Message = "Hello from controller to View";
        return View();
    }
    public IActionResult Browse()
    {
        ViewBag.Message = "<h1>Hello from controller to View</h1>";
        return View();
    }
}
