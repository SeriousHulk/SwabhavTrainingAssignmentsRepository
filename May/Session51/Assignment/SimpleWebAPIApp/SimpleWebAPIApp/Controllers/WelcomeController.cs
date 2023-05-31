using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleWebAPIApp.Controllers
{
    public class WelcomeController : ApiController
    {
        public WelcomeController()
        {
            
        }
        public string Get()
        {
            return "Get Called";
        }
        public string Post()
        {
            return "Post Called";
        }
        public string Put()
        {
            return "Post Called";
        }
        public string Delete()
        {
            return "Post Called";
        }
    }
}