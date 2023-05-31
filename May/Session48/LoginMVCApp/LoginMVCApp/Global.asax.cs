using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoginMVCApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application["Counter"] = 0;
        }
        protected void Session_Start()
        {
            Session["Counter"] = 0;
            Session["Cart"] = null;
            Session["userName"] = null;
        }
    }
}
