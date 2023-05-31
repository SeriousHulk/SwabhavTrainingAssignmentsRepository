using login_welcome_app.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    private static List<LoginVM> loginVMs = new List<LoginVM>()
        {
            new LoginVM { UserName = "Vikrant", UserPassword = "pass@123" },
        };
    private bool IsValidCredentials(string username, string password)
    {
        return loginVMs.Any(credential =>
            string.Equals(credential.UserName, username, StringComparison.OrdinalIgnoreCase) &&
            credential.UserPassword == password);
    }
    [HttpPost]
    public IActionResult Index(LoginVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        HttpContext.Session.SetString("UserName", model.UserName);

        return RedirectToAction("Index", "Welcome");
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Login");
    }
}