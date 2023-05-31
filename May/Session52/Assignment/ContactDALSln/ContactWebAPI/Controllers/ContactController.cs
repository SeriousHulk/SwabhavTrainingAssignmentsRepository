using ContactDALLib.Model;
using ContactDALLib.Repository;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContactWebAPI.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    [RoutePrefix("api/v1/Contacts")]
    public class ContactController : ApiController
    {
        private readonly ContactRepository contactRepository;
        public ContactController()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ContactDB;Integrated Security=True";
            contactRepository = new ContactRepository(connectionString);
        }
        [Route("GetAllContacts")]
        public IHttpActionResult GetAllContacts() 
        {
            var contacts = contactRepository.GetContacts();
            return Ok(contacts);
        }
        [Route("GetContactById/{id}")]
        public IHttpActionResult GetContact(int id)
        {
            ContactDALLib.Model.Contact contact = contactRepository.GetContactById(id);
            if (contact == null)
            {
                contact = contactRepository.GetContactById(1);
            }
            return Ok(contact);
        }
        [HttpPost]
        [Route("AddContact")]   
        public IHttpActionResult AddContact(ContactDALLib.Model.Contact c)
        {
            if (ModelState.IsValid)
            {
                var contact = new ContactDALLib.Model.Contact
                {
                    Name = c.Name,
                    MobileNumber = c.MobileNumber
                };
                contactRepository.AddContact(contact);
            }
            return Ok(c);
        }
        [Route("UpdateContact")]
        [HttpPut]
        public IHttpActionResult UpdateContact(ContactDALLib.Model.Contact contact) {
            contactRepository.UpdateContact(contact.Id, contact);
            return Ok();
        }
        [Route("DeleteContact/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteContact(int id)
        {
            if(GetContact(id)== null)
                return NotFound();
            contactRepository.DeleteContact(id);
            return Ok();
        }
    }
}
