using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClosedXML_Excel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            Console.ReadKey();

            List<Employee> list = new List<Employee>();

            list.Add(new Employee { ID = 1, Name = "OK", IsActive = true, HireDate = DateTime.Now });

            ClosedXmlReader.WriteEmployees("output.xlsx", list);

            Console.WriteLine("Saved");
            Console.WriteLine("Press For Read");
            Console.ReadKey();

            list = ClosedXmlReader.ReadEmployees("output.xlsx");

            Console.WriteLine(list.Count);

            Console.WriteLine("OK");
            Console.ReadKey();
        }

        static DataTable readWithoutTable(string filePath)
        {
            var dt = new DataTable();
            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1);
                bool firstRow = true;

                foreach (var row in ws.RowsUsed())
                {
                    if (firstRow)
                    {
                        foreach (var cell in row.Cells())
                            dt.Columns.Add(cell.Value.ToString());
                        firstRow = false;
                    }
                    else
                    {
                        var dataRow = dt.NewRow();
                        int i = 0;
                        foreach (var cell in row.Cells(1, dt.Columns.Count))
                        {
                            if (cell.DataType == XLDataType.DateTime)
                                dataRow[i++] = cell.GetDateTime();
                            else if (cell.DataType == XLDataType.Number)
                                dataRow[i++] = cell.GetDouble();
                            else if (cell.DataType == XLDataType.Boolean)
                                dataRow[i++] = cell.GetBoolean();
                            else
                                dataRow[i++] = cell.GetValue<string>();
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
            }
            return dt;
        }

        static void writeWithoutTable(string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Sheet1");

                ws.Cell(1, 1).Value = "ID";
                ws.Cell(1, 2).Value = "Name";

                ws.Cell(2, 1).Value = 1;
                ws.Cell(2, 2).Value = "Alice";

                workbook.SaveAs("output.xlsx");
            }
        }
    }
}