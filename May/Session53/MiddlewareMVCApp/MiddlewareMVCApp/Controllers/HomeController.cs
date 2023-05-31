using Microsoft.AspNetCore.Mvc;
using MiddlewareMVCApp.Models;
using MiddlewareMVCApp.Services;
using System.Diagnostics;

namespace MiddlewareMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailServices _emailServices;
        public HomeController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
            Console.WriteLine("HomeController created!");
        }
        public async Task<IActionResult> Index()
        {
            await _emailServices.SendEmail("Home Controller", "admin", "Email Sent");
            Console.WriteLine("at Controller");
            return Content("<h1>Welcome to Index Page Of Home</h1>","text/html");
        }
    }
}