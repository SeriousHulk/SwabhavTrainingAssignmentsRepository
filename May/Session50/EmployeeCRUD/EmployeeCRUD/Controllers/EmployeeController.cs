using EmployeeCRUD.Services;
using EmployeeCRUD.ViewModels;
using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Security;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController()
        {
            _employeeService = new EmployeeDbService();
        }
        public ActionResult Index()
        {
            EmployeeVM vm = new EmployeeVM();
            vm.Title = "Employee Home Page";
            vm.Employees = _employeeService.Get();
            vm.Count = _employeeService.Count();
            return View(vm);
        }
        [Authorize]
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
        [Authorize]
        public ActionResult Edit(int? id)
        {
            EmployeeEditVM vm = new EmployeeEditVM();
            vm.Title = "Edit Employee";
            if(id!=null)
            {
                Employee emp = _employeeService.Get((int)id);
                vm.EmployeeId = emp.Id;
                vm.EmployeeName = emp.Name;
                vm.EmployeeSalary = emp.Salary;
            }
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeEditVM vm) { 
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            _employeeService.Update(vm.EmployeeId,new Employee { Id = vm.EmployeeId, Name =vm.EmployeeName, Salary=vm.EmployeeSalary });
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                _employeeService.Delete((int)id);
            }
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}