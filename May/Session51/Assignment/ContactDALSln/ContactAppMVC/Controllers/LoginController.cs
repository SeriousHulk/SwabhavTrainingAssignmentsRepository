using ContactAppMVC.ViewModel;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ContactAppMVC.Controllers
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
        public ActionResult Index(LoginVM vm, string ReturnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            FormsAuthentication.SetAuthCookie(vm.UserName, false);
            Session["username"] = vm.UserName;
            return RedirectToAction("ShowAllContacts", "Contact");
        }

    }
}