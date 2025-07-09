using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;

namespace UserStorySimilarityAddIn
{
    public static class ExcelReader
    {
        public static List<string> ReadUserStories(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var stories = new List<string>();
            using var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets[0];

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var cellValue = worksheet.Cells[row, 1].Text;
                if (!string.IsNullOrWhiteSpace(cellValue))
                    stories.Add(cellValue);
            }

            return stories;
        }
    }
}
