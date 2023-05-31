using EmployeeCRUD.EF.Repository;
using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Services
{
    public class EmployeeDbService : IEmployeeService
    {
        private EmployeeRepository _employeeRepository;
        public EmployeeDbService()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public void Add(Employee employee)
        {
           _employeeRepository.Add(employee);
        }

        public int Count()
        {
            return _employeeRepository.HeadCount();
        }

        public void Delete(int id)
        {
            _employeeRepository.Remove(id);
        }

        public List<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public void Update(int id, Employee employee)
        {
            _employeeRepository.Update(id, employee);
        }
    }
}