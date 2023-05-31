using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleEFApp.Model;

namespace SimpleEFApp.EF
{
    public class CustomerDbContext:DbContext
    {
        public CustomerDbContext() : base("CustomerDbContext")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
