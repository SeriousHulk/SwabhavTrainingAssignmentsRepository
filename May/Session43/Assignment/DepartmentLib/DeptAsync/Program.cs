using DepartmentLib;
using DepartmentLib.Model;

namespace DeptApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
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
                        await AddDepartmentAsync(departmentRepository);
                        break;
                    case "2":
                        await DisplayDepartmentsAsync(departmentRepository);
                        break;
                    case "3":
                        await CountDepartmentsAsync(departmentRepository);
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
        static async Task AddDepartmentAsync(DepartmentRepository departmentRepository)
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

            await departmentRepository.AddAsync(department);
            Console.WriteLine("Department added successfully.");
        }
        static async Task DisplayDepartmentsAsync(DepartmentRepository departmentRepository)
        {
            var departments = await departmentRepository.GetAsync();

            Console.WriteLine("Departments:");
            foreach (var department in departments)
            {
                Console.WriteLine($"DEPTNO: {department.DeptNo}, DNAME: {department.DName}, LOC: {department.Location}");
            }
        }
        static async Task CountDepartmentsAsync(DepartmentRepository departmentRepository)
        {
            int count = await departmentRepository.CountAsync();
            Console.WriteLine($"Total departments: {count}");
        }
    }
}