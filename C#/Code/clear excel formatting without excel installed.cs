using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

var filePath = "path_to_your_excel_file.xlsx";
FileInfo fileInfo = new FileInfo(filePath);

using (var package = new ExcelPackage(fileInfo))
{
    var worksheet = package.Workbook.Worksheets[0]; // First worksheet

    // Clear formatting for a range (e.g., A1:C10)
    var range = worksheet.Cells["A1:C10"];
    range.StyleID = 0; // Reset to default style

    package.Save();
}