Provider=Microsoft.ACE.OLEDB.12.0

using System;
using System.Data;
using System.Data.OleDb;

public static class ExcelAceReader
{
    public static DataTable ReadExcel(string filePath)
    {
        string connStr = $@"
            Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source={filePath};
            Extended Properties='Excel 12.0 Xml;HDR=YES;'";

        using (var conn = new OleDbConnection(connStr))
        {
            conn.Open();

            // Get the first worksheet name
            DataTable sheets = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string sheetName = sheets.Rows[0]["TABLE_NAME"].ToString();

            // Read data
            var adapter = new OleDbDataAdapter($"SELECT * FROM [{sheetName}]", conn);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}


using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;

public static class ExcelAceWriter
{
    public static void WriteExcel(string filePath, DataTable dt)
    {
        string connStr = $@"
            Provider=Microsoft.ACE.OLEDB.12.0;
            Data Source={filePath};
            Extended Properties='Excel 12.0 Xml;HDR=YES;'";

        using (var conn = new OleDbConnection(connStr))
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


DataTable dt = ExcelAceReader.ReadExcel(@"C:\data\input.xlsx");
ExcelAceWriter.WriteExcel(@"C:\data\output.xlsx", dt);