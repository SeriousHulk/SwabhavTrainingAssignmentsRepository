using System.Configuration;
using System.Data;
using System.Data.SqlClient;

var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";

SqlConnection connection = new SqlConnection(connectionString);
try
{
    connection.Open();
    Console.WriteLine($"Successfully Connected from core to {connection.Database}");
}
catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
finally
{
    if (connection.State == ConnectionState.Open)
    {
        connection.Close();
    }
}