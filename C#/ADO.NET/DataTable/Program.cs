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

        static void example1()
        {
            DataTable table = new DataTable("TableName");

            DataColumn col1 = new DataColumn("col1", typeof(int));
            DataColumn col2 = new DataColumn("col2", typeof(string));

            DataColumnCollection columnCollection = table.Columns;
            columnCollection.AddRange(new DataColumn[] { col1, col2 });

            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine("{0}: {1}", column.ColumnName, column.DataType);
            }

            DataRow r = table.NewRow();

            r["col1"] = 1;
            r["col2"] = "one";

            table.Rows.Add(r);

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
                }
            }
        }

        static void example2()
        {
            DataTable table = new DataTable("TableName");

            table.Columns.Add(new DataColumn("col1", typeof(int)));
            table.Columns.Add(new DataColumn("col2", typeof(string)));

            DataRow r = table.NewRow();

            r["col1"] = 1;
            r["col2"] = "one";

            table.Rows.Add(r);

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine("{0}: {1}", column.ColumnName, row[column]);
                }
            }
        }

        static void Main(string[] args)
        {
            example1();

            Console.WriteLine("-------------------------------------");

            example2();

            Console.ReadKey();
        }

    }
}