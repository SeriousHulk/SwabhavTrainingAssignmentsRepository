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
            //CaseStudy4();
            //CaseStudy5();
            //CaseStudy6();
            CaseStudy7();
            Console.ReadLine();
        }

        private static void CaseStudy7()
        {
            var db = new CustomerDbContext();
            var customer = db.Customers.ToList().
                Select(c => new
                {
                    FirstName = c.Name.Split()[0]
                });
            customer.ToList().ForEach(c => Console.WriteLine(c.FirstName));
        }

        private static async void CaseStudy6()
        {
            var db = new CustomerDbContext();
            var customer = db.Customers.
                Select(c => new
                {
                    FirstName = c.Name.Split()[0]
                });
            await customer.ForEachAsync(c => Console.WriteLine(c.FirstName));
        }

        private static void CaseStudy5()
        {
            var db = new CustomerDbContext();
            var customer = db.Customers.Where(c => c.Name.Equals("Anekant")).First();
            customer.Address = "Monocept" + customer.Address ;
            customer.Name = customer.Name.ToUpper();
            db.SaveChanges();
        }

        private static void CaseStudy4()
        {
            var db = new CustomerDbContext();
            var customer = db.Customers.Where(c => c.Name.Equals("Vikrant")).ToList();
            customer.ForEach(c=>Console.WriteLine(c.Name));
        }

        private static void CaseStudy3()
        {
            var db = new CustomerDbContext();
            var customer =db.Customers.Where(c => c.Name.Equals("Vikrant")).First();
            Console.WriteLine(customer.Name);
        }

        private static async void CaseStudy2()
        {
            var db = new CustomerDbContext();
            await db.Customers.ForEachAsync<Customer>(c => Console.WriteLine(c.Name));
        }

        private static void CaseStudy1()
        {
            var c1 = new Customer { Id = 1 , Name="Vikrant", Address="Monocept"};
            var c2 = new Customer { Id = 2, Name = "Anekant", Address = "Hyderabad" };
            var db = new CustomerDbContext();
            db.Customers.Add(c1);
            db.Customers.Add(c2);
            db.SaveChanges();
        }
    }
}
