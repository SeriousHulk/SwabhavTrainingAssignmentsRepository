using EmployeeMVCcoreCRUD.Models;
using EmployeeMVCcoreCRUD.Services;
using EmployeeMVCcoreCRUD.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVCcoreCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            //_employeeService = new EmployeeInMemoryServices();
        }
        public IActionResult Index()
        {
            EmployeeVM vm = new EmployeeVM();
            vm.Title = "Employee Details";
            vm.Employees = _employeeService.Get();
            vm.Count = _employeeService.Count();
            return View(vm);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            EmployeeAddVM vm = new EmployeeAddVM();
            //vm.Title = "Add Employee";
            return View(vm);
        }
        [HttpPost]
        public IActionResult Add(EmployeeAddVM vm)
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
            return RedirectToAction("Index","Employee");
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
            EmployeeEditVM vm = new EmployeeEditVM();
            //vm.Title = "Edit Employee";
            if (id != null)
            {
                Employee emp = _employeeService.Get((int)id);
                vm.EmployeeId = emp.Id;
                vm.EmployeeName = emp.Name;
                vm.EmployeeSalary = emp.Salary;
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            _employeeService.Update(vm.EmployeeId, new Employee { Id = vm.EmployeeId, Name = vm.EmployeeName, Salary = vm.EmployeeSalary });
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _employeeService.Delete((int)id);
            }
            return RedirectToAction("Index","Employee");
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Employee");
        }
    }
}
