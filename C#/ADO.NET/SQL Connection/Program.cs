using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = @"Data Source=(local)\V;Initial Catalog=AdventureWorks2014;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.StateChange+=connection_StateChange;
                
                try
                {
                    connection.Open();

                    Console.WriteLine(connection.State);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            Console.ReadLine();

        }

        static void connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            SqlConnection Conn = sender as SqlConnection;

            Console.WriteLine("Database State: {0}\n", Conn.State);
        }

    }
}