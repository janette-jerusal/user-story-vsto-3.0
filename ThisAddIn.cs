using System;
using Microsoft.Office.Tools.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace UserStorySimilarityAddIn
{
    public partial class ThisAddIn
    {
        private MyRibbon ribbon;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Manual test to invoke and verify ribbon loading
            ribbon = new MyRibbon();
            string result = ribbon.GetCustomUI("MyRibbon");
            System.Windows.Forms.MessageBox.Show("Ribbon XML Loaded:\n\n" + result);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new MyRibbon();
        }

        #region VSTO generated code

        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}

