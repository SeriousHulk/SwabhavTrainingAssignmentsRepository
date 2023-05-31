using ContactDALLib.EF;
using ContactDALLib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDALLib.Repository
{
    public class ContactRepository
    {
        private string connectionString;
        public ContactRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AddContact(Contact contact)
        {
            using (var context = new ContactDbContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }
        public List<Contact> GetContacts()
        {
            using (var context = new ContactDbContext())
            {
                return context.Contacts.ToList();
            }
        }
        public Contact GetContactById(int id)
        {
            using (var context = new ContactDbContext()) { 
            return context.Contacts.Where(c => c.Id == id).FirstOrDefault();
            }
        }
        public void UpdateContact(int id,Contact contact)
        {
            using (var context = new ContactDbContext())
            {
                Contact _contact = GetContactById(id);
                if (_contact != null)
                {
                    _contact.Id = contact.Id;
                    _contact.Name = contact.Name;
                    _contact.MobileNumber = contact.MobileNumber;
                    context.SaveChanges();
                }
            }
        }
    }
}
