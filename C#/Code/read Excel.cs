using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

public class ExcelInteropReader
{
    public static DataTable ReadExcelToDataTable(string filePath)
    {
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
        Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
        Excel.Range xlRange = xlWorksheet.UsedRange;

        DataTable dt = new DataTable();

        int rowCount = xlRange.Rows.Count;
        int colCount = xlRange.Columns.Count;

        // Add columns from header row (assumed to be row 1)
        for (int j = 1; j <= colCount; j++)
        {
            string colName = xlRange.Cells[1, j].Value2?.ToString() ?? $"Column{j}";
            dt.Columns.Add(colName);
        }

        // Read the rest of the data starting from row 2
        for (int i = 2; i <= rowCount; i++)
        {
            DataRow dr = dt.NewRow();
            for (int j = 1; j <= colCount; j++)
            {
                dr[j - 1] = xlRange.Cells[i, j].Value2?.ToString() ?? "";
            }
            dt.Rows.Add(dr);
        }

        // Cleanup
        xlWorkbook.Close(false);
        xlApp.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

        return dt;
    }
}
