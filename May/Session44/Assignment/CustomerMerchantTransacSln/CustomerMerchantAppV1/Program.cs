using System.Data.SqlClient;

namespace CustomerMerchantAppV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MonoceptDB;Integrated Security=True";

            Console.Write("Enter CID: ");
            int cid = int.Parse(Console.ReadLine());

            Console.Write("Enter MID: ");
            string mid = Console.ReadLine();

            Console.Write("Enter Amount to transact: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update Customer command
                    string updateCustomerSql = "UPDATE Customer SET cbalance = cbalance - @Amount WHERE cid = @CID";
                    using (SqlCommand cmd1 = new SqlCommand(updateCustomerSql, connection))
                    {
                        cmd1.Parameters.AddWithValue("@Amount", amount);
                        cmd1.Parameters.AddWithValue("@CID", cid);

                        int rowsAffected1 = cmd1.ExecuteNonQuery();

                        if (rowsAffected1 == 0)
                        {
                            Console.WriteLine("Customer not found.");
                            return;
                        }
                    }

                    // Update Merchant command
                    string updateMerchantSql = "UPDATE Merchant SET mbalance = mbalance + @Amount WHERE mid = @MID";
                    using (SqlCommand cmd2 = new SqlCommand(updateMerchantSql, connection))
                    {
                        cmd2.Parameters.AddWithValue("@Amount", amount);
                        cmd2.Parameters.AddWithValue("@MID", mid);

                        int rowsAffected2 = cmd2.ExecuteNonQuery();

                        if (rowsAffected2 == 0)
                        {
                            Console.WriteLine("Merchant not found.");
                            return;
                        }
                    }

                    Console.WriteLine("Transaction completed successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}