using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.EF.Repository
{
    public class EmployeeRepository
    {
        private EmployeeDbContext dbContext;
        public EmployeeRepository()
        {
            dbContext = new EmployeeDbContext();
        }
        public void Add(Employee emp)
        {
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
        }
        public List<Employee> GetAll()
        {
            return dbContext.Employees.ToList();
        }
        public Employee Get(int id)
        {
            return dbContext.Employees.SingleOrDefault(emp => emp.Id == id);
        }
        public int HeadCount()
        {
            return dbContext.Employees.Count();
        }
        public void Remove(int id)
        {
            dbContext.Employees.Remove(Get(id));
            dbContext.SaveChanges();
        }
        public void Update(int id,Employee employee) {
            var emp = Get(id);
            emp.Name = employee.Name;
            emp.Salary = employee.Salary;
            dbContext.SaveChanges();
        }
    }
}