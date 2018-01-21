using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class Program
    {
        static SqlConnectionStringBuilder ConnectionBuilder = new SqlConnectionStringBuilder
        {
            DataSource = @"(local)\V",
            InitialCatalog = "AdventureWorks2014",
            IntegratedSecurity = true,
            Pooling = true, // if true connection will not be closed
            UserID = "",
            Password = ""
        };

        static void Main(string[] args)
        {

            using (SqlConnection cnn = new SqlConnection(ConnectionBuilder.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM XTABLE WHERE ID = -99999;", cnn);

                try
                {
                    cnn.Open();

                    cmd.Transaction = cnn.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();

                    Console.WriteLine("Commited");

                    cnn.Close();
                }
                catch(Exception ex)
                {
                    cmd.Transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }

    }
}