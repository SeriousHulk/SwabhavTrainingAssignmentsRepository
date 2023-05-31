using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Transactions;


string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";


using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    SqlTransaction sqlTran = connection.BeginTransaction();
    SqlCommand command = connection.CreateCommand();
    command.Transaction = sqlTran;
        Console.Write("Enter amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter merchant ID: ");
        int merchantId = Convert.ToInt32(Console.ReadLine());
    try
    {
        string checkMerchantExists = "SELECT COUNT(*) FROM Merchant WHERE MID = @MID";
        using (SqlCommand checkMerchantCmd = new SqlCommand(checkMerchantExists, connection, sqlTran))
        {
            checkMerchantCmd.Parameters.AddWithValue("@MID", merchantId);
            int merchantCount = Convert.ToInt32(checkMerchantCmd.ExecuteScalar());

            if (merchantCount == 0)
            {
                Console.WriteLine("Merchant not found.");
                sqlTran.Rollback();
                return;
            }
        }

        // Update Customer table
        command.CommandText = "UPDATE Customer SET cbalance = cbalance - @amount WHERE cid = @cid";
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@cid", customerId);
        command.ExecuteNonQuery();

        // Update Merchant table
        command.CommandText = "UPDATE Merchant SET mbalance = mbalance + @amount WHERE mid = @mid";
        command.Parameters.Clear();
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@mid", merchantId);
        command.ExecuteNonQuery();
        sqlTran.Commit();
        Console.WriteLine("Both records were written to database.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        try
        {
            sqlTran.Rollback();
        }
        catch (Exception exRollback)
        {
            Console.WriteLine(exRollback.Message);
        }
    }
}