using EmployeeMVCcoreCRUD.Models;

namespace EmployeeMVCcoreCRUD.Services
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        int Count();
        void Delete(int id);
        List<Employee> Get();
        Employee Get(int id);
        void Update(int id, Employee employee);
    }
}
