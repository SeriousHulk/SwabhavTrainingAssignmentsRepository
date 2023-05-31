using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactDALLib.Model;
using ContactDALLib.Repository;


namespace ContactAppMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactRepository contactRepository;
        public ContactController()
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ContactDB;Integrated Security=True";
            contactRepository = new ContactRepository(connectionString);
        }

        [Route]
        public ActionResult ShowAllContacts()
        {            
            var contacts = contactRepository.GetContacts();
            return View(contacts);
        }
        public ActionResult ShowSingle(int id = 1)
        {
            ViewBag.key = id;
            Contact contact = contactRepository.GetContactById(id);
            if (contact == null)
            {
                contact = contactRepository.GetContactById(1);
            }
            return View(contact);
        }
    }
}


//using ContactDALLib.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//namespace ContactMVCApp1.Controllers
//{
//    public class ContactsController : Controller
//    {        // GET: Contacts
//        private readonly ContactRepository contactRepository;
//        public ContactsController()
//        {
//            // Provide the connection string to the ContactRepository
//            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ContactDB;Integrated Security=True";
//            contactRepository = new ContactRepository(connectionString);
//        }
//        // GET: Contacts/ShowAll
//        public ActionResult ShowAll()
//        {            // Retrieve all contacts from the repository
//            var contacts = contactRepository.GetContacts();
//        // Pass the contacts to the view
//            return View(contacts);
//    }
//        // GET: Contacts/ShowSingle/1
//        public ActionResult ShowSingle(int id)
//        {            // Retrieve a single contact based on the provided id
//            var contact = contactRepository.GetContactById(id);
//    // Pass the contact to the view
//            return View(contact);
//}
//    }}