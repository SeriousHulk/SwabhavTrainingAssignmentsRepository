using DepartmentLib.Model;
using DepartmentLib;

namespace DeptApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";
            DepartmentRepository departmentRepository = new DepartmentRepository(connectionString);
            while (true)
            {
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Display Departments");
                Console.WriteLine("3. Count Departments");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDepartment(departmentRepository);
                        break;
                    case "2":
                        DisplayDepartments(departmentRepository);
                        break;
                    case "3":
                        CountDepartments(departmentRepository);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
        static void AddDepartment(DepartmentRepository departmentRepository)
        {
            Console.Write("Enter Department Number: ");
            if (!int.TryParse(Console.ReadLine(), out int deptNo))
            {
                Console.WriteLine("Invalid Department Number.");
                return;
            }

            Console.Write("Enter Department Name: ");
            string deptName = Console.ReadLine();

            Console.Write("Enter Department Location: ");
            string deptLoc = Console.ReadLine();

            Department department = new Department
            {
                DeptNo = deptNo,
                DName = deptName,
                Location = deptLoc
            };

            departmentRepository.Add(department);
            Console.WriteLine("Department added successfully.");
        }
        static void DisplayDepartments(DepartmentRepository departmentRepository)
        {
            var departments = departmentRepository.Get();

            Console.WriteLine("Departments:");
            foreach (var department in departments)
            {
                Console.WriteLine($"DEPTNO: {department.DeptNo}, DNAME: {department.DName}, LOC: {department.Location}");
            }
        }
        static void CountDepartments(DepartmentRepository departmentRepository)
        {
            int count = departmentRepository.Count();
            Console.WriteLine($"Total departments: {count}");
        }
    }
}