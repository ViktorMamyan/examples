using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace NPOI_Excel
{
    public static class NpoiReader
    {
        public static List<Employee> ReadEmployees(string filePath)
        {
            var employees = new List<Employee>();
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    var row = sheet.GetRow(rowIndex);
                    if (row == null) continue;

                    var emp = new Employee();
                    emp.ID = (int)row.GetCell(0).NumericCellValue;
                    emp.Name = row.GetCell(1).StringCellValue;
                    emp.HireDate = (DateTime)(DateUtil.IsCellDateFormatted(row.GetCell(2)) ? row.GetCell(2).DateCellValue : DateTime.MinValue);
                    emp.IsActive = row.GetCell(3).BooleanCellValue;

                    employees.Add(emp);
                }
            }
            return employees;
        }

        public static void WriteEmployees(string filePath, List<Employee> employees)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Employees");

            // Header row
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("ID");
            headerRow.CreateCell(1).SetCellValue("Name");
            headerRow.CreateCell(2).SetCellValue("HireDate");
            headerRow.CreateCell(3).SetCellValue("IsActive");

            // Data rows
            for (int i = 0; i < employees.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                var e = employees[i];
                row.CreateCell(0).SetCellValue(e.ID);
                row.CreateCell(1).SetCellValue(e.Name);
                row.CreateCell(2).SetCellValue(e.HireDate);
                row.CreateCell(3).SetCellValue(e.IsActive);
            }

            // Autosize columns
            for (int i = 0; i < 4; i++)
            {
                sheet.AutoSizeColumn(i);
            }

            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }
    }
}