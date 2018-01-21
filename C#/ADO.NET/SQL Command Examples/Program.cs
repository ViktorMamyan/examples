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

        static void Main(string[] args)
        {
            //using QueryToSqlServer with no parameters
            DataTable dt = dbclass.QueryToSqlServer("Select 1 AS c;", CommandType.Text);
            Console.WriteLine(dt.Rows[0][0].ToString());

            //using QueryToSqlServer with parameters
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@a", "a"));
            Parameters.Add(new SqlParameter("@b", "b"));

            DataTable dt2 = dbclass.QueryToSqlServer("Select @a,@b AS c;", CommandType.Text,Parameters.ToArray());
            Console.WriteLine(dt2.Rows[0][0].ToString());

            //using ExecuteSQL with no parameters
            dbclass.ExecuteSQL("UPDATE table SET [Status] = 1;", CommandType.Text);

            //using ExecuteSQL with parameters
            List<SqlParameter> Parameters2 = new List<SqlParameter>();
            Parameters2.Add(new SqlParameter("@a", "a"));
            Parameters2.Add(new SqlParameter("@b", "b"));
            Parameters2.Add(new SqlParameter("@c", "c"));
            Parameters2.Add(new SqlParameter("@d", "d"));
            dbclass.ExecuteSQL("ProcedureName", CommandType.StoredProcedure, Parameters2.ToArray());

            //using QueryScalar with no parameters
            object o = dbclass.QueryScalar("SELECT dbo.FunctionName();");

            //using QueryScalar with parameters
            List<SqlParameter> Parameters3 = new List<SqlParameter>();
            Parameters3.Add(new SqlParameter("@a", "a"));
            Parameters3.Add(new SqlParameter("@b", "b"));
            object o2 = dbclass.QueryScalar("SELECT dbo.FunctionName(@a,@b);");

            //passing datatable variable as parameter
            DataTable T=new DataTable();//set datatable values
            List<SqlParameter> Parameters4 = new List<SqlParameter>();
            Parameters4.Add(new SqlParameter("@a", "a"));
            SqlParameter p = new SqlParameter("@DataTableVariable", T)
            {
                TypeName="dbo.TypeName"
            };
            dbclass.ExecuteSQL("ProcedureName", CommandType.StoredProcedure, Parameters4.ToArray());

            Console.ReadKey();
        }

    }
}