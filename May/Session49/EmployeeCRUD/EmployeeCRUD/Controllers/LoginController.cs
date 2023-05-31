using EmployeeCRUD.ViewModel;
using System.Diagnostics;
using System.Web.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class LoginController : Controller
    {
        public LoginController() {}
        [HttpGet]
        public ActionResult Index()
        {
            LoginVM vm = new LoginVM();
            vm.UserName = "Vikrant";
            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(LoginVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            Debug.WriteLine("\n\n\n");
            Debug.WriteLine(Session["username"]);
            Session["username"] = vm.UserName;
            return RedirectToAction("Index","Employee");
        }
       
    }
}