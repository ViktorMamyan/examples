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
                cnn.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP (50) FirstName,LastName FROM Person.Person;", cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader.GetName(i) + ": " + reader[i]);
                    }
                    Console.WriteLine(new string('_',20));
                }

                reader.Close();

                cnn.Close();
            }

            Console.ReadKey();
        }

    }
}