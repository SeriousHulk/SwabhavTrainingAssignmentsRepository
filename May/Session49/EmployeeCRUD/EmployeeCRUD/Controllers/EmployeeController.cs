using EmployeeCRUD.Services;
using EmployeeCRUD.ViewModels;
using EmployeeCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService = new EmployeeService();
        public EmployeeController()
        {
            _employeeService = EmployeeService.GetInstance();
        }
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
            if (Session["username"] == null)
                return RedirectToAction("Index", "Login");

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
        
        public ActionResult Edit(int? id)
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Login");
            
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
        public ActionResult Delete(int? id)
        {
            if (Session["username"] == null)
                return RedirectToAction("Index", "Login");
            if (id != null)
            {
                _employeeService.Delete((int)id);
            }
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}