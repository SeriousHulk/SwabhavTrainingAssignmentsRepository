using CustomAnnotationPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomAnnotationPOC.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        //Post values of Student form
        [HttpPost]
        public ActionResult Create(Student student)
        {
            //check if Model value are valid and as required 
            if (ModelState.IsValid)
            {
                //Yes Valid Model, Save values in database or do something
            }
            else
            {
                return View();
            }
            return RedirectToAction("Create");
        }

    }
}