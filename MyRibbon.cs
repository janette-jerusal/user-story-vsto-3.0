using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace UserStorySimilarityAddIn
{
    public class MyRibbon : IRibbonExtensibility
    {
        private IRibbonUI ribbon;

        public MyRibbon()
        {
            MessageBox.Show("Ribbon constructor called");
        }

        public string GetCustomUI(string ribbonID)
        {
            MessageBox.Show("GetCustomUI triggered");

            var assembly = Assembly.GetExecutingAssembly();
            string res = "UserStorySimilarityAddIn.MyRibbonUI.xml";  // Update this if your namespace or filename changes

            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(res))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string xml = reader.ReadToEnd();
                    MessageBox.Show("Ribbon XML content:\n" + xml); // Debugging
                    return xml;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Ribbon XML: " + ex.Message);
                return null;
            }
        }

        public void OnLoad(IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void OnCompareClick(IRibbonControl control)
        {
            MessageBox.Show("Compare button clicked!");
        }
    }
}

