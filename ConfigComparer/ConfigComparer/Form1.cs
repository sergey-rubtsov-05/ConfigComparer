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
            XDocument doc = XDocument.Load("ConfigComparer.exe.config");
            var dict = new Dictionary<string, string>();
            if (doc.Root != null)
                foreach (var xElement in doc.Root.Elements())
                {
                    if (xElement.Name == ("appSettings"))
                    {
                        foreach (var element in xElement.Elements())
                        {
                            dict.Add(element.Attribute("key").Value, element.Attribute("value").Value);
                        }
                    }
                }
            dict = dict.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
            int yForLabels = 35;
            foreach (var setting in dict)
            {
                var label = new Label();
                label.AutoSize = true;
                label.Name = "label" + setting.Key;
                label.Text = setting.Key;
                label.Location = new Point(15, yForLabels);

                var textBox = new TextBox();
                textBox.Enabled = false;
                textBox.Text = setting.Value;
                textBox.Name = "textBox" + setting.Value;
                textBox.AutoSize = true;
                textBox.Location = new Point(label.Location.X + label.Size.Width + 10, yForLabels - 3);
                yForLabels += 20;

                Controls.Add(label);
                Controls.Add(textBox);
            }
        }
    }
}
