using System.Data;
using System.IO;
using OfficeOpenXml;

namespace UserStorySimilarityAddIn
{
    public static class ExcelReader
    {
        public static DataTable ReadUserStories(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                var ws = package.Workbook.Worksheets[0];
                return ws.ToDataTable();
            }
        }

        private static DataTable ToDataTable(this ExcelWorksheet ws)
        {
            var tbl = new DataTable();
            foreach (var cell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                tbl.Columns.Add(cell.Text);

            for (int r = 2; r <= ws.Dimension.End.Row; r++)
            {
                var row = tbl.NewRow();
                for (int c = 1; c <= ws.Dimension.End.Column; c++)
                    row[c - 1] = ws.Cells[r, c].Text;
                tbl.Rows.Add(row);
            }

            return tbl;
        }
    }
}
