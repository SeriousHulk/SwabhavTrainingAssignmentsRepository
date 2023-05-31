using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using login_welcome_app.Models;

namespace login_welcome_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
}
