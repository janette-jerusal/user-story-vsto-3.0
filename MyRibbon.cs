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
            MessageBox.Show("Ribbon Constructor Called");
        }

        public string GetCustomUI(string ribbonID)
        {
            MessageBox.Show("GetCustomUI triggered!");

            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            MessageBox.Show("Resources:\n" + string.Join("\n", resources));

            foreach (var res in resources)
            {
                if (res.Contains("MvRibbon"))
                {
                    using (Stream stream = assembly.GetManifestResourceStream(res))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var xml = reader.ReadToEnd();
                        MessageBox.Show("Ribbon XML loaded:\n\n" + xml);
                        return xml;
                    }
                }
            }

            MessageBox.Show("MvRibbon.xml not found in embedded resources.");
            return null;
        }

        public void OnLoad(IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        // 🔘 This connects to the onAction="OnCompareClick" in your XML
        public void OnCompareClick(IRibbonControl control)
        {
            MessageBox.Show("Compare button clicked!");
        }
    }
}
