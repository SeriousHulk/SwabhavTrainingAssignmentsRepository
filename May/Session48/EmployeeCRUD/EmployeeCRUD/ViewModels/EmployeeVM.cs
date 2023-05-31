using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.ViewModels
{
    public class EmployeeVM
    {
        public int Count { get; set; }
        public string Title { get; set; }
        public List<Employee> Employees { get; set; }
    }
}