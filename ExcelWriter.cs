using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace UserStorySimilarityAddIn
{
    public static class ExcelWriter
    {
        public static void WriteResults(string outputPath, List<(string, string, double)> results)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Similarity Results");

            worksheet.Cells[1, 1].Value = "Story A";
            worksheet.Cells[1, 2].Value = "Story B";
            worksheet.Cells[1, 3].Value = "Similarity Score";

            for (int i = 0; i < results.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = results[i].Item1;
                worksheet.Cells[i + 2, 2].Value = results[i].Item2;
                worksheet.Cells[i + 2, 3].Value = results[i].Item3;
            }

            package.SaveAs(new FileInfo(outputPath));
        }
    }
}
