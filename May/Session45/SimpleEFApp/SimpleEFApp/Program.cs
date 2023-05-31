using SimpleEFApp.EF;
using SimpleEFApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace SimpleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CaseStudy1();
            //CaseStudy2();
            //CaseStudy3();
            CaseStudy4();
            Console.ReadLine();
        }

        private static void CaseStudy4()
        {
            var department1 = new Department();
            department1.Name = "Sales";

            var employee1 = new Employee();
            employee1.Name = "Gautam";
            employee1.Department = department1;

            var employee2 = new Employee();
            employee1.Name = "Anekant";
            employee1.Department = department1;

            department1.Employees.Add(employee1);
            department1.Employees.Add(employee2);

            var db = new CustomerDbContext();
            db.Departments.Add(department1);
            db.SaveChanges();

            Console.WriteLine("End of Case Study 4");
        }

        private static void CaseStudy3()
        {
            var db = new CustomerDbContext();
            foreach(var c in db.Customers.Include(c=>c.Orders))
            {
                Console.WriteLine(c.Name);
                c.Orders.ForEach(o=>Console.WriteLine(o.Description));
            }
        }

        private static async void CaseStudy2()
        {
            var db = new CustomerDbContext();
            await db.Orders.ForEachAsync(order => Console.WriteLine(order.Description));
        }

        private static void CaseStudy1()
        {
            var c1 = new Customer();
            c1.Name = "Gautam";
            c1.Address = "Hyderabad";

            var order1 = new Order();
            order1.Date = DateTime.Now;
            order1.Description = "Books";
            order1.Customer = c1;

            var order2 = new Order();
            order2.Date = DateTime.Now;
            order2.Description = "Pencils";
            order2.Customer = c1;

            c1.Orders.Add(order1);
            c1.Orders.Add(order2);

            var db = new CustomerDbContext();
            db.Customers.Add(c1);
            db.SaveChanges();

            Console.WriteLine("End of Case Study 1");
        }
    }
}
