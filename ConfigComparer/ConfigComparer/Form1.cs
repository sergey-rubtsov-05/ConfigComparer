using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
            
        }

        private void GetSettingsDict(XDocument doc, Dictionary<string, string> settingsDict, Dictionary<string, string> repeatedSettingsDict)
        {
            if (doc.Root != null)
                foreach (var xElement in doc.Root.Elements())
                {
                    if (xElement.Name == ("appSettings"))
                    {
                        foreach (var element in xElement.Elements())
                        {
                            try
                            {
                                settingsDict.Add(element.Attribute("key").Value, element.Attribute("value").Value);
                            }
                            catch (ArgumentException)
                            {
                                repeatedSettingsDict.Add(element.Attribute("key").Value, element.Attribute("value").Value);
                            }
                        }
                    }
                }
        }

        private void selectFirstSettingsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XDocument doc = XDocument.Load(openFileDialog1.FileName);
                var settingsDict = new Dictionary<string, string>();
                var repeatedSettingsDict = new Dictionary<string, string>();
                GetSettingsDict(doc, settingsDict, repeatedSettingsDict);
                settingsDict = settingsDict.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
                foreach (var setting in settingsDict)
                {
                    dataGridViewSettings1.Rows.Add(setting.Key, setting.Value);
                }
                foreach (var repeatSetting in repeatedSettingsDict)
                {
                    dataGridViewRepeatedSettings1.Rows.Add(repeatSetting.Key, repeatSetting.Value);
                }
            }
        }

        private void selectSecondSettingsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XDocument doc = XDocument.Load(openFileDialog1.FileName);
                var settingsDict = new Dictionary<string, string>();
                var repeatedSettingsDict = new Dictionary<string, string>();
                GetSettingsDict(doc, settingsDict, repeatedSettingsDict);
                settingsDict = settingsDict.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
                foreach (var setting in settingsDict)
                {
                    dataGridViewSettings2.Rows.Add(setting.Key, setting.Value);
                }
                foreach (var repeatSetting in repeatedSettingsDict)
                {
                    dataGridViewRepeatedSettings2.Rows.Add(repeatSetting.Key, repeatSetting.Value);
                }
            }
        }
    }
}
