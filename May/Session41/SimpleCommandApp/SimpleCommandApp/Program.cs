using System.Data.SqlClient;

//ReadFromDB();
//ReadByID();
CaseStudy3();

void CaseStudy3()
{
    Console.WriteLine("Enter an ID");
    var id = Console.ReadLine();

    var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";
    var connection = new SqlConnection(connectionString);
    connection.Open();
    var command = new SqlCommand("select * from Student where id=@id", connection);
    command.Parameters.AddWithValue("@id", id);
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader["name"]);
    }
    reader.Close();
    connection.Close();
}

void ReadByID()
{
    Console.WriteLine("Enter an ID");
    var id = Console.ReadLine();

    var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";
    var connection = new SqlConnection(connectionString);
    connection.Open();
    var command = new SqlCommand($"select * from Student where id={id}", connection);
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader["name"]);
    }
    reader.Close();
    connection.Close();
}

static void ReadFromDB()
{
    var connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";
    var connection = new SqlConnection(connectionString);
    connection.Open();
    var command = new SqlCommand("select * from Student", connection);
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader["name"]);
    }
    reader.Close();
    connection.Close();
}