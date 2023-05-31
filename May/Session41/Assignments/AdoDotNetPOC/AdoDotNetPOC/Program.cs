using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;


//Data Source=.\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True
//Console.WriteLine("Enter ID");
//int _id = int.Parse( Console.ReadLine());
//Console.WriteLine("Enter Name");
//string _name = Console.ReadLine();
//Console.WriteLine("Enter Location");
//string _location = Console.ReadLine();
using (SqlConnection connection = new SqlConnection("server=.\\sqlexpress;initial catalog=MonoceptDB;integrated security=true;"))
{
    SqlCommand sqlCommand = new SqlCommand();
    sqlCommand.CommandType = CommandType.Text;
    sqlCommand.Connection = connection;
    //DeleteFromDB(_id, connection, sqlCommand);
    //UpdateDB(_id, _name, _location, connection, sqlCommand);
    ReadFromDB(sqlCommand);
    //InsertIntoDB(_name, _location, connection, sqlCommand);

}

static void InsertIntoDB(string _name, string _location, SqlConnection connection, SqlCommand sqlCommand)
{
    sqlCommand.CommandText = "insert into Student(name,location)values(@name,@location)";
    sqlCommand.Parameters.AddWithValue("@name", _name);
    sqlCommand.Parameters.AddWithValue("@location", _location);

    connection.Open();
    int _rows = sqlCommand.ExecuteNonQuery();
    connection.Close();

    if (_rows > 0)
    {
        Console.WriteLine("Command Executed successfully!");
    }
    else { Console.WriteLine("Failed to Inserrt!"); }
}

static void ReadFromDB(SqlCommand sqlCommand)
{
    sqlCommand.CommandText = "select * from Student";
    DataTable dataTable = new DataTable();
    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
    adapter.Fill(dataTable);
    if (dataTable.Rows.Count > 0)
    {
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"{row[0]}    {row[1]}    {row[2]}");
        }
    }
}

static void UpdateDB(int _id, string _name, string _location, SqlConnection connection, SqlCommand sqlCommand)
{
    sqlCommand.CommandText = "update Student set name=@name,location=@location where id=@id";
    sqlCommand.Parameters.AddWithValue("@id", _id);
    sqlCommand.Parameters.AddWithValue("@name", _name);
    sqlCommand.Parameters.AddWithValue("@location", _location);

    connection.Open();
    int _rows = sqlCommand.ExecuteNonQuery();
    connection.Close();

    if (_rows > 0)
    {
        Console.WriteLine($"{_rows} rows updated successfully!");
    }
    else { Console.WriteLine("Failed to Inserrt!"); }
}

static void DeleteFromDB(int _id, SqlConnection connection, SqlCommand sqlCommand)
{
    sqlCommand.CommandText = "delete from Student where id=@id";
    sqlCommand.Parameters.AddWithValue("@id", _id);

    connection.Open();
    int _rows = sqlCommand.ExecuteNonQuery();
    connection.Close();

    if (_rows > 0)
    {
        Console.WriteLine("Row Deleted successfully!");
    }
    else { Console.WriteLine("Failed to Delete/ Invalid ID!"); }
}