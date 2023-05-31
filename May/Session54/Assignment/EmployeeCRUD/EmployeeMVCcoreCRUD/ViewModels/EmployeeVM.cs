using EmployeeMVCcoreCRUD.Models;

namespace EmployeeMVCcoreCRUD.ViewModels
{
    public class EmployeeVM
    {
        public int Count { get; set; }
        public string Title { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
