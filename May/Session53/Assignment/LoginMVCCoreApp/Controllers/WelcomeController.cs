using Microsoft.AspNetCore.Mvc;

namespace LoginMVCCoreApp.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("Username");
            string password = HttpContext.Session.GetString("Password");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Username = username;
            ViewBag.Password = password;
            return View();
        }
    }
}
