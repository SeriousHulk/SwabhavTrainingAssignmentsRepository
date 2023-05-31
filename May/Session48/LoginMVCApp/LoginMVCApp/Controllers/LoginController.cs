using LoginMVCApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVCApp.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            
        }
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
            /*
            if(string.IsNullOrEmpty(vm.UserName) || string.IsNullOrEmpty(vm.UserPassword))
            {
                vm.Title = "User name or password null";
                return View(vm);
            }
            *
            */

            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            Session["userName"] = vm.UserName;
            return RedirectToAction("Index","Welcome");
        }
    }
}