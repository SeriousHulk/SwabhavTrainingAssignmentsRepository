using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public string Hello()
        {
            return "Hello";
        }
        public ActionResult Browse()
        {
            var company = new
            {
                Name = "Monocept",
                Location = "Mumbai"
            };
            var random = new Random();
            int randomValue = random.Next(1, 10);
            if (randomValue == 0)
            {
                return Json(company, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound("No valid number generated" + randomValue);
            }
        }
        public ActionResult ShowStudents(string name = "Monocept")
        {
            ViewBag.key1 = "value1";
            ViewBag.key2 = "value2";
            ViewBag.Name = name;
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ContentResult Display(int id = 0)
        {
            return Content("<h1>Displaying details for id passed :"+id+"</h1>");
        }
    }
}