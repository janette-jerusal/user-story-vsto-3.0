using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace UserStorySimilarityAddIn
{
    public partial class SimilarityForm : Form
    {
        public SimilarityForm() { InitializeComponent(); }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string file1 = txtFile1.Text;
            string file2 = txtFile2.Text;

            if (!File.Exists(file1) || !File.Exists(file2))
            {
                MessageBox.Show("Please select two valid Excel files.");
                return;
            }

            try
            {
                var df1 = ExcelReader.ReadUserStories(file1);
                var df2 = ExcelReader.ReadUserStories(file2);

                var results = SimilarityEngine.ComputeSimilarity(df1, df2, (float)thresholdSlider.Value / 100);
                var outputPath = ExcelWriter.WriteResults(results);

                MessageBox.Show("Comparison complete! Results saved to:\n" + outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Excel Files (*.xlsx)|*.xlsx" };
            if (ofd.ShowDialog() == DialogResult.OK) txtFile1.Text = ofd.FileName;
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog { Filter = "Excel Files (*.xlsx)|*.xlsx" };
            if (ofd.ShowDialog() == DialogResult.OK) txtFile2.Text = ofd.FileName;
        }
    }
}
