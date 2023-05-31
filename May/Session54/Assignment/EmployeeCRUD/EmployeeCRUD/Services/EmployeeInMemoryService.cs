using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Services
{
    public class EmployeeInMemoryService : IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>();
        private static EmployeeInMemoryService _bucket;
        public EmployeeInMemoryService()
        {
            _employees.Add(new Employee { Id = 1, Name = "Anekant", Salary = 24000 });
            _employees.Add(new Employee { Id = 2, Name = "Vikrant", Salary = 26000 });
        }
        public List<Employee> Get()
        {
            return _employees;
        }
        public int Count()
        {
            return _employees.Count;
        }
        public Employee Get(int id)
        {
            return _employees.First(x => x.Id == id);
        }
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }
        public void Update(int id, Employee employee)
        {
            var empl = Get(id);
            if (empl != null)
            {
                empl.Name = employee.Name;
                empl.Salary = employee.Salary;
            }
        }

        public static EmployeeInMemoryService GetInstance()
        {
            if (_bucket == null)
            {
                _bucket = new EmployeeInMemoryService();
            }
            return _bucket;
        }

        public void Delete(int id)
        {
            var empl = Get(id);
            _employees.Remove(empl);
        }
    }
}