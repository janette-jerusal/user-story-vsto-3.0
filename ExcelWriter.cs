using System;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace UserStorySimilarityAddIn
{
    public static class ExcelWriter
    {
        public static string WriteResults(DataTable table)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "UserStoryResults.xlsx");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Matches");
                sheet.Cells["A1"].LoadFromDataTable(table, true);
                package.SaveAs(new FileInfo(filePath));
            }

            return filePath;
        }
    }
}
