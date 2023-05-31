using CustomerWebApiAppV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CustomerWebApiAppV2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/customer")]

    public class CustomerController : ApiController
    {

        public CustomerController()
        {

        }
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer{ Id =1,Name ="Vikrant"},
            new Customer{ Id =2,Name ="Ravi"}
        };
        [Route("GetAllCustomers")]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(_customers);
        }
        [HttpPost]
        [Route("AddCustomer")]
        public IHttpActionResult AddCustomer(Customer customer)
        {
            _customers.Add(customer);
            return Ok();
        }
    }
}
