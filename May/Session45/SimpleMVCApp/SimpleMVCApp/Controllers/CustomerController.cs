using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        public string GetAll()
        {
            return "Anekant,Vikrant,Ekta";
        }
    }
}