using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ConfigComparer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(@"D:\Work\DF-V4Repository\Sources\DT.Everest.DocFlow.Web.Explorer\bin\DT.Everest.DocFlow.Web.Explorer.dll.config");
            var dict = new Dictionary<string, string>();
            if (doc.Root != null)
                foreach (var xElement in doc.Root.Elements())
                {
                    if (xElement.Name == ("appSettings"))
                    {
                        foreach (var element in xElement.Elements())
                        {
                            try
                            {
                                dict.Add(element.Attribute("key").Value, element.Attribute("value").Value);
                            }
                            catch (ArgumentException ae)
                            {
                                //MessageBox.Show(ae.Message + ": " + element.Attribute("key").Value);
                            }
                        }
                    }
                }
            dict = dict.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
            foreach (var setting in dict)
            {
                dataGridView1.Rows.Add(setting.Key, setting.Value);
            }
        }
    }
}
