using System;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace UserStorySimilarityAddIn
{
    public class MyRibbon : IRibbonExtensibility
    {
        private IRibbonUI ribbon;

        public string GetCustomUI(string ribbonID)
        {
            return System.IO.File.ReadAllText(
                System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Ribbon.xml"
                )
            );
        }

        public void Ribbon_Load(IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void OnCompareClick(IRibbonControl control)
        {
            MessageBox.Show("Compare button clicked!");
            // TODO: Replace with your real form or logic here
            // new SimilarityForm().ShowDialog();
        }
    }
}

