using EmployeeMVCcoreCRUD.Models;

namespace EmployeeMVCcoreCRUD.Services
{
    public class EmployeeInMemoryServices:IEmployeeService
    {
        private List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Anekant", Salary = 26000 },
            new Employee { Id = 2, Name = "Vikrant", Salary = 26000 },
            new Employee { Id = 3, Name = "Gautam", Salary = 26000 },
            new Employee { Id = 4, Name = "Ekta", Salary = 26000 },
            new Employee { Id = 5, Name = "Manjunath", Salary = 26000 },
            new Employee { Id = 6, Name = "Ravi", Salary = 26000 },
            new Employee { Id = 7, Name = "Shubh", Salary = 26000 }
        };
        //private static EmployeeInMemoryServices _bucket;
        public EmployeeInMemoryServices()
        {
            Console.WriteLine("InMemory Service CTOR");
            //_employees.Add(new Employee { Id = 1, Name = "Anekant", Salary = 26000 });
            //_employees.Add(new Employee { Id = 2, Name = "Vikrant", Salary = 26000 });
            //_employees.Add(new Employee { Id = 3, Name = "Gautam", Salary = 26000 });
            //_employees.Add(new Employee { Id = 4, Name = "Ekta", Salary = 26000 });
            //_employees.Add(new Employee { Id = 5, Name = "Manjunath", Salary = 26000 });
            //_employees.Add(new Employee { Id = 6, Name = "Ravi", Salary = 26000 });
            //_employees.Add(new Employee { Id = 7, Name = "Shubh", Salary = 26000 });
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

        //public static EmployeeInMemoryServices GetInstance()
        //{
        //    if (_bucket == null)
        //    {
        //        _bucket = new EmployeeInMemoryServices();
        //    }
        //    return _bucket;
        //}

        public void Delete(int id)
        {
            var empl = Get(id);
            _employees.Remove(empl);
        }
    }
}
