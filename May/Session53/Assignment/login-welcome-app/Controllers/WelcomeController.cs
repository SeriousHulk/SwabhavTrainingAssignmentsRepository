using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Login");
            }

            var welcomeMessage = "Welcome " + username;
            ViewBag.Message = welcomeMessage;

            return View();
        }
    }
}
