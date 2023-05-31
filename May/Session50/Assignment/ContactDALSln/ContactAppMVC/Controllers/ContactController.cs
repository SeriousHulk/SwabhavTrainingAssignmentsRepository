using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactAppMVC.ViewModel;
using ContactDALLib.EF;
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
        public ActionResult AddContact()
        {
            AddVM vm = new AddVM();
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(AddVM vm)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact
                {
                    Name = vm.Name,
                    MobileNumber = vm.Mobile
                };
                contactRepository.AddContact(contact);
                return RedirectToAction("ShowAllContacts", "Contact");
            }
            return View(vm);
        }
        public ActionResult EditContact(int id)
        {
            EditVM vm = new EditVM();
            vm.Title = "Edit Contact";
                Contact contact1 = contactRepository.GetContactById((int)id);
                vm.Name = contact1.Name;
                vm.Mobile = contact1.MobileNumber;
            return View(vm);
        }
        [HttpPost]
        public ActionResult EditContact(EditVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            contactRepository.UpdateContact(vm.Id,new Contact { MobileNumber = vm.Mobile, Name = vm.Name });
            return RedirectToAction("ShowAllContacts");
        }
        public ActionResult DeleteContact(int id)
        {
            using (var context = new ContactDbContext())
            {
                Contact contact = context.Contacts.Find(id);

                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("ShowAllContacts");
        }
    }
}