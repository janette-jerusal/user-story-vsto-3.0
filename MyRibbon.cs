using System;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace UserStorySimilarityAddIn
{
    public partial class MyRibbon
    {
        private void MyRibbon_Load(object sender, RibbonUIEventArgs e) { }

        private void btnCompare_Click(object sender, RibbonControlEventArgs e)
        {
            SimilarityForm form = new SimilarityForm();
            form.Show();
        }
    }
}
