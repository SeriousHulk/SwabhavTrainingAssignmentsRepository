using ContactDALLib.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDALLib.EF
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext() : base("name=ContactDbContext")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
