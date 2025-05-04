using ClosedXML.Excel;
using System.Collections.Generic;
using System.Linq;

namespace ClosedXML_Excel
{
    public static class ClosedXmlReader
    {
        public static List<Employee> ReadEmployees(string filePath)
        {
            var employees = new List<Employee>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var ws = workbook.Worksheet(1);
                foreach (var row in ws.RowsUsed().Skip(1))
                {
                    var emp = new Employee
                    {
                        ID = int.Parse(row.Cell(1).GetValue<string>()),
                        Name = row.Cell(2).GetValue<string>(),
                        HireDate = row.Cell(3).GetDateTime(),
                        IsActive = row.Cell(4).GetBoolean()
                    };
                    employees.Add(emp);
                }
            }
            return employees;
        }

        public static void WriteEmployees(string filePath, List<Employee> employees)
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Employees");

                // Headers
                ws.Cell(1, 1).Value = "ID";
                ws.Cell(1, 2).Value = "Name";
                ws.Cell(1, 3).Value = "HireDate";
                ws.Cell(1, 4).Value = "IsActive";

                // Data
                for (int i = 0; i < employees.Count; i++)
                {
                    var e = employees[i];
                    ws.Cell(i + 2, 1).Value = e.ID;
                    ws.Cell(i + 2, 2).Value = e.Name;
                    ws.Cell(i + 2, 3).Value = e.HireDate;
                    ws.Cell(i + 2, 4).Value = e.IsActive;
                }

                // Add table
                var range = ws.Range(1, 1, employees.Count + 1, 4);
                range.CreateTable();

                workbook.SaveAs(filePath);
            }
        }
    }
}