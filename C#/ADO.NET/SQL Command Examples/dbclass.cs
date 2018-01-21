using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public static class dbclass
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

        //return query with no parameters
        public static DataTable QueryToSqlServer(string CommandText, CommandType SqlCommandType)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cnn = new SqlConnection(ConnectionBuilder.ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = SqlCommandType;
                    cmd.CommandText = CommandText;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                cnn.Close();
            }
            return dt;
        }

        //return query with parameters
        public static DataTable QueryToSqlServer(string CommandText, CommandType SqlCommandType, SqlParameter[] p)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cnn = new SqlConnection(ConnectionBuilder.ConnectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = SqlCommandType;
                    cmd.CommandText = CommandText;
                    cmd.Parameters.AddRange(p);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                cnn.Close();
            }
            return dt;
        }

        //execute procedure with no parameters
        public static void ExecuteSQL(string CommandText, CommandType SqlCommandType)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = SqlCommandType;
                    cmd.CommandText = CommandText;

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //exec procedure with parameters
        public static void ExecuteSQL(string CommandText, CommandType SqlCommandType, SqlParameter[] p)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = SqlCommandType;
                    cmd.CommandText = CommandText;

                    cmd.Parameters.AddRange(p);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
        }

        //return scalar query with no parameters
        public static object QueryScalar(string CommandText)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = CommandText;

                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();

                    return o;
                }
            }
        }

        //return scalar query with parameters
        public static object QueryScalar(string CommandText, SqlParameter[] p)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionBuilder.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = CommandText;
                    cmd.Parameters.AddRange(p);

                    cnn.Open();
                    object o = cmd.ExecuteScalar();
                    cnn.Close();

                    return o;
                }
            }
        }

    }
}