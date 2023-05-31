using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVCApp.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult Index()
        {
            Session["Counter"] = (int)Session["Counter"] + 1;
            return View();
        }
    }
}