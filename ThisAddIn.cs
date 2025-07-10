using System;
using Microsoft.Office.Tools.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace UserStorySimilarityAddIn
{
    public partial class ThisAddIn
    {
        protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new MyRibbon(); // Excel uses this
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Optional: useful debug only, but remove later
            // MessageBox.Show("ThisAddIn Startup triggered.");
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
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

