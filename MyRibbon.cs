using System.Reflection;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Core;

namespace UserStorySimilarityAddIn
{
    public class MyRibbon : IRibbonExtensibility
    {
        private IRibbonUI ribbon;

        public MyRibbon()
        {
            // Confirm constructor is triggered
            MessageBox.Show("Ribbon Constructor Called");
        }

        public string GetCustomUI(string ribbonID)
        {
            try
            {
                MessageBox.Show("Ribbon Constructor Called");

                var assembly = Assembly.GetExecutingAssembly();
                var resources = assembly.GetManifestResourceNames();

                MessageBox.Show("Resources:\n" + string.Join("\n", resources));

                using (Stream stream = assembly.GetManifestResourceStream("UserStorySimilarityAddIn.MvRibbon.xml"))
                {
                    if (stream == null)
                    {
                        MessageBox.Show("Ribbon XML not found");
                        return null;
                    }

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error loading ribbon: " + ex.Message);
                return null;
            }
        }
