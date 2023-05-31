using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomActionFilter.Filter
{
    public class CustomFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Debug.WriteLine("Hello from CustomFilter OnActionExecuting");
            filterContext.Controller.ViewBag.Message = "Message From Custom filter OnActionExecuting Method";
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("Hello from CustomFilter OnActionExecuted");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Debug.WriteLine("Hello from CustomFilter OnResultExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine("Hello from CustomFilter OnResultExecuted");
        }
    }
}