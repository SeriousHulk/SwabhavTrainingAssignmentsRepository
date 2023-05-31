using LoginMVCCoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LoginMVCCoreApp.Controllers{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Username", model.Username);
                HttpContext.Session.SetString("Password", model.Password);

                return RedirectToAction("Index", "Welcome");
            }

            return View(model);
        }
    }
}