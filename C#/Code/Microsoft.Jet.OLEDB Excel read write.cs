Microsoft.Jet.OLEDB

//Use .xls files only (not .xlsx)
//On a 64-bit machine, your app must run as 32-bit (Jet is 32-bit only)
//Make sure Excel is not open during the operation

using System;
using System.Data;
using System.Data.OleDb;

public static class ExcelJetReader
{
    public static DataTable ReadExcel(string filePath)
    {
        string connStr = $@"
            Provider=Microsoft.Jet.OLEDB.4.0;
            Data Source={filePath};
            Extended Properties='Excel 8.0;HDR=YES;'";

        using (OleDbConnection conn = new OleDbConnection(connStr))
        {
            conn.Open();

            // Get sheet name
            DataTable sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = sheets.Rows[0]["TABLE_NAME"].ToString();

            // Read data
            string query = $"SELECT * FROM [{sheetName}]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}


using System;
using System.Data;
using System.Data.OleDb;

public static class ExcelJetWriter
{
    public static void WriteExcel(string filePath, DataTable dt)
    {
        string connStr = $@"
            Provider=Microsoft.Jet.OLEDB.4.0;
            Data Source={filePath};
            Extended Properties='Excel 8.0;HDR=YES;'";

        using (OleDbConnection conn = new OleDbConnection(connStr))
        {
            conn.Open();

            // Create table
            string create = "CREATE TABLE [Sheet1] (";
            foreach (DataColumn col in dt.Columns)
                create += $"[{col.ColumnName}] TEXT,";
            create = create.TrimEnd(',') + ")";
            new OleDbCommand(create, conn).ExecuteNonQuery();

            // Insert data
            foreach (DataRow row in dt.Rows)
            {
                string cols = string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => $"[{c.ColumnName}]"));
                string vals = string.Join(",", row.ItemArray.Select(v => $"'{v.ToString().Replace("'", "''")}'"));
                string insert = $"INSERT INTO [Sheet1$] ({cols}) VALUES ({vals})";
                new OleDbCommand(insert, conn).ExecuteNonQuery();
            }
        }
    }
}


var dt = ExcelJetReader.ReadExcel("data.xls");
ExcelJetWriter.WriteExcel("output.xls", dt);