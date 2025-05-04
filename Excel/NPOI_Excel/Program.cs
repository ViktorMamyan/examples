using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;

namespace NPOI_Excel
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }


        public static DataTable ReadExcelToDataTable(string filePath)
        {
            var dt = new DataTable();

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                IRow headerRow = sheet.GetRow(0);
                for (int i = 0; i < headerRow.LastCellNum; i++)
                {
                    dt.Columns.Add(headerRow.GetCell(i)?.ToString() ?? $"Column{i}");
                }

                for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    var row = sheet.GetRow(rowIndex);
                    if (row == null) continue;

                    var dataRow = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        var cell = row.GetCell(i);
                        if (cell == null)
                        {
                            dataRow[i] = DBNull.Value;
                            continue;
                        }

                        switch (cell.CellType)
                        {
                            case CellType.Boolean:
                                dataRow[i] = cell.BooleanCellValue;
                                break;
                            case CellType.Numeric:
                                if (DateUtil.IsCellDateFormatted(cell))
                                    dataRow[i] = cell.DateCellValue;
                                else
                                    dataRow[i] = cell.NumericCellValue;
                                break;
                            case CellType.String:
                                dataRow[i] = cell.StringCellValue;
                                break;
                            case CellType.Formula:
                                dataRow[i] = cell.ToString(); // or cell.StringCellValue
                                break;
                            default:
                                dataRow[i] = cell.ToString();
                                break;
                        }
                    }
                    dt.Rows.Add(dataRow);
                }
            }

            return dt;
        }

        public static void WriteExcelToDataTable(string filePath)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("Sheet1");
            var row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("ID");
            row.CreateCell(1).SetCellValue("Name");

            var row1 = sheet.CreateRow(1);
            row1.CreateCell(0).SetCellValue(1);
            row1.CreateCell(1).SetCellValue("Bob");

            using (var fs = new FileStream("output.xlsx", FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
        }
    }
}