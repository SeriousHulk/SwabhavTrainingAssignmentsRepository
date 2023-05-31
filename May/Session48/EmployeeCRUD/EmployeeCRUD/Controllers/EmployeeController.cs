using EmployeeCRUD.Services;
using EmployeeCRUD.ViewModels;
using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService = new EmployeeService();
        public EmployeeController()
        {
            _employeeService = EmployeeService.GetInstance();
        }
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeVM vm = new EmployeeVM();
            vm.Title = "Employee Home Page";
            vm.Employees = _employeeService.Get();
            vm.Count = _employeeService.Count();
            return View(vm);
        }
        [HttpGet]
        public ActionResult Add()
        {
            EmployeeAddVM vm = new EmployeeAddVM();
            vm.Title = "Add Employee";
            return View(vm);
        }
        [HttpPost]
        public ActionResult Add(EmployeeAddVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            _employeeService.Add(new Employee
            {
                Id = vm.EmployeeId,
                Name = vm.EmployeeName,
                Salary = vm.EmployeeSalary
            });
            return RedirectToAction("Index");
        }
    }
}