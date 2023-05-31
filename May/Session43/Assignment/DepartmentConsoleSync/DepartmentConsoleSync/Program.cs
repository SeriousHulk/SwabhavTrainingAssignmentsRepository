using System.Data.SqlClient;
using System.Threading.Channels;

public class Program
{
    public static List<Department> Get()
    {
        var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";
        var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand("select * from DEPT", connection);
        var reader = command.ExecuteReader();
        List<Department> deptList = new List<Department>();

        while (reader.Read())
        {
            Department dept = new Department
            {
                DeptNo = Convert.ToInt32(reader["DEPTNO"]),
                DName = reader["DNAME"].ToString(),
                Location = reader["LOC"].ToString(),
            };
            deptList.Add(dept);
        }
        reader.Close();
        connection.Close();
        return deptList;
    }
    public static void Add(Department department)
    {
        var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";
        var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand("INSERT INTO DEPT(DNAME,LOCATION)VALUES(@NAME,@LOCATION)", connection);
        command.Parameters.AddWithValue("@DEPTNO", department.DeptNo);
        command.Parameters.AddWithValue("@DNAME", department.DName);
        command.Parameters.AddWithValue("@LOC", department.Location);
        connection.Close();
    }
    public static int Count()
    {
        int count = 0;
        var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM DEPT";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            count = (int)command.ExecuteScalar();
        }

        return count;
    }
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEnter Your Choice:");
            Console.WriteLine("1.Create new Department");
            Console.WriteLine("2.Show all Departments");
            Console.WriteLine("3.Display Count of Departments");
            var choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter Department Name");
                    string i_name = Console.ReadLine();
                    Console.WriteLine("Enter Location");
                    string i_location = Console.ReadLine();
                    AddNewDepartment(i_name, i_location);
                    break;
                case "2":
                    PrintDepartmentDetails();
                    break;
                case "3":
                    ShowCount();
                    break;
                default:
                    Console.WriteLine("Invalid Choice!\n");
                    break;
            }
        }
    }

    private static void ShowCount()
    {
        Console.WriteLine("Total no of companies "+Count());
    }

    private static void AddNewDepartment(string? name, string? location)
    {
        Department department = new Department();
        department.DName = name;
        department.Location = location;
        Add(department);
    }

    private static void PrintDepartmentDetails()
    {
        List<Department> department = Get();
        Console.WriteLine("Details of all Departments:");
        Console.WriteLine("No.    Name     Location");
        foreach(Department dep in department)
        {
            Console.WriteLine(dep.DeptNo+"   "+dep.DName+"       "+dep.Location);
        }
    }

}
public class Department
{
    public int DeptNo { get; set; }
    public string DName { get; set; }
    public string Location { get; set; }
}

