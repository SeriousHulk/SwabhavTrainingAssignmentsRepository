using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EmployeeMVCcoreCRUD.ViewModels;

namespace EmployeeMVCcoreCRUD.Controllers
{
    public class LoginController : Controller
    {
        public LoginController() { }
        [HttpGet]
        public ActionResult Index()
        {
            LoginVM vm = new LoginVM();
            vm.UserName = "Vikrant";
            return View(vm);
        }
        [HttpPost]
        public async Task<ActionResult> Index(LoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, vm.UserName),
                // Add any additional claims if needed
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Employee");
        }
    }
}
