using CustomActionFilter.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomActionFilter.Controllers
{
    public class HomeController : Controller
    {
        [CustomFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}