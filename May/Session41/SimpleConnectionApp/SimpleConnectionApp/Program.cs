using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SimpleConnectionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";
            Console.WriteLine(ConfigurationManager.ConnectionStrings["productionEnv"].ConnectionString);
            var connectionString = ConfigurationManager.ConnectionStrings["productionEnv"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine($"Successfully Connected to {connection.Database}");
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
