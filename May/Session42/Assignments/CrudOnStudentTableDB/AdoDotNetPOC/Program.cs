using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

using (SqlConnection connection = new SqlConnection("server=.\\sqlexpress;initial catalog=MonoceptDB;integrated security=true;"))
{

    SqlCommand sqlCommand = new SqlCommand();
    sqlCommand.CommandType = CommandType.Text;
    sqlCommand.Connection = connection;
    while (true)
    {
        Console.WriteLine("\nEnter Your Choice:");
        Console.WriteLine("1.Create new Student");
        Console.WriteLine("2.Find a Student");
        Console.WriteLine("3.Show all Student");
        Console.WriteLine("4.Update a Student");
        Console.WriteLine("5.Delete a Student");
        var choice = Console.ReadLine();
        Console.WriteLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Enter Name");
                string i_name = Console.ReadLine();
                Console.WriteLine("Enter Location");
                string i_location = Console.ReadLine();
                InsertIntoDB(i_name, i_location, connection, sqlCommand);
                break;
            case "2":
                Console.WriteLine("Enter ID");
                int f_id = int.Parse(Console.ReadLine());
                FindAStudent(f_id,sqlCommand,connection);
                break;
            case "3":
                ReadFromDB(sqlCommand,connection);
                break;
            case "4":
                Console.WriteLine("Enter ID");
                int u_id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name");
                string u_name = Console.ReadLine();
                Console.WriteLine("Enter Location");
                string u_location = Console.ReadLine();
                UpdateDB(u_id, u_name, u_location, connection, sqlCommand);
                break;
            case "5":
                Console.WriteLine("Enter ID");
                int d_id = int.Parse(Console.ReadLine());
                DeleteFromDB(d_id, connection, sqlCommand);
                break;
            default:
                Console.WriteLine("Invalid Choice!\n");
                break;
        }
    }
    //DeleteFromDB(_id, connection, sqlCommand);
    //UpdateDB(_id, _name, _location, connection, sqlCommand);
    //ReadFromDB(sqlCommand,connection);
    //InsertIntoDB(_name, _location, connection, sqlCommand);

}

static void InsertIntoDB(string insert_name, string insert_location, SqlConnection connection, SqlCommand sqlCommand)
{
    sqlCommand.CommandText = "insert into Student(name,location)values(@name,@location)";
    sqlCommand.Parameters.AddWithValue("@name", insert_name);
    sqlCommand.Parameters.AddWithValue("@location", insert_location);

    connection.Open();
    int _rows = sqlCommand.ExecuteNonQuery();
    connection.Close();

    if (_rows > 0)
    {
        Console.WriteLine("Command Executed successfully!\n");
    }
    else { Console.WriteLine("Failed to Inserrt!\n"); }
}

static void ReadFromDB(SqlCommand sqlCommand,SqlConnection connection)
{
    sqlCommand.CommandText = "select * from Student";
    DataTable dataTable = new DataTable();
    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
    adapter.Fill(dataTable);
    if (dataTable.Rows.Count > 0)
    {
        Console.WriteLine("id   name    location");
        Console.WriteLine("---------------------");
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"{row[0]}    {row[1]}    {row[2]}");
        }
    }
}

static void FindAStudent(int find_id, SqlCommand sqlCommand, SqlConnection connection)
{
    sqlCommand.CommandText = "select * from Student where id=@id";
    sqlCommand.Parameters.AddWithValue("@id", find_id);
    DataTable dataTable = new DataTable();
    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
    adapter.Fill(dataTable);
    Console.WriteLine($"");
    if (dataTable.Rows.Count > 0)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"{row[0]}    {row[1]}    {row[2]}");
        }
    }
}

static void UpdateDB(int update_id, string update_name, string update_location, SqlConnection connection, SqlCommand sqlCommand)
{
    sqlCommand.CommandText = "update Student set name=@name,location=@location where id=@id";
    sqlCommand.Parameters.AddWithValue("@id", update_id);
    sqlCommand.Parameters.AddWithValue("@name", update_name);
    sqlCommand.Parameters.AddWithValue("@location", update_location);

    connection.Open();
    int _rows = sqlCommand.ExecuteNonQuery();
    connection.Close();

    if (_rows > 0)
    {
        Console.WriteLine($"{_rows} rows updated successfully!\n");
    }
    else { Console.WriteLine("Failed to Inserrt!\n"); }
}

static void DeleteFromDB(int delete_id, SqlConnection connection, SqlCommand sqlCommand)
{
    sqlCommand.CommandText = "delete from Student where id=@id";
    sqlCommand.Parameters.AddWithValue("@id", delete_id);

    connection.Open();
    int _rows = sqlCommand.ExecuteNonQuery();
    connection.Close();

    if (_rows > 0)
    {
        Console.WriteLine("Row Deleted successfully!\n");
    }
    else { Console.WriteLine("Failed to Delete/ Invalid ID!\n"); }
}