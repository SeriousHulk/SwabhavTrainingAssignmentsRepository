using ContactDALLib.EF;
using ContactDALLib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDALLib.Repository
{
    public class ContactRepository
    {
        private string connectionString;
        private ContactDbContext _dbContext;

        public ContactRepository(string connectionString)
        {
            this.connectionString = connectionString;
            _dbContext = new ContactDbContext();
        }
        public void AddContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
        }
        public List<Contact> GetContacts()
        {
            return _dbContext.Contacts.ToList();
        }
        public Contact GetContactById(int id)
        {
            return _dbContext.Contacts.Where(c => c.Id == id).FirstOrDefault();
        }
        public void UpdateContact(int id, Contact contact)
        {
            Contact _contact = GetContactById(id);
            if (_contact != null)
            {
                _contact.Name = contact.Name;
                _contact.MobileNumber = contact.MobileNumber;
                Debug.WriteLine(_contact.Name);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteContact(int id)
        {
            Contact contact = GetContactById(id);
            if (contact != null)
            {
                _dbContext.Contacts.Remove(contact);
                _dbContext.SaveChanges();
            }
        }
    }
}
