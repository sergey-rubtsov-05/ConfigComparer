using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ConfigComparer
{
    public partial class Form1 : Form
    {

        Dictionary<string, string> _settingsDict1 = new Dictionary<string, string>();
        Dictionary<string, string> repeatedSettingsDict1 = new Dictionary<string, string>();

        Dictionary<string, string> _settingsDict2 = new Dictionary<string, string>();
        Dictionary<string, string> repeatedSettingsDict2 = new Dictionary<string, string>();

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
                            element.Attribute("value").Value = "Check2";
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
                GetSettingsDict(doc, _settingsDict1, repeatedSettingsDict1);
                doc.Save(openFileDialog1.FileName);
                _settingsDict1 = _settingsDict1.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
                foreach (var setting in _settingsDict1)
                {
                    dataGridViewSettings1.Rows.Add(setting.Key, setting.Value);
                }
                foreach (var repeatSetting in repeatedSettingsDict1)
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
                GetSettingsDict(doc, _settingsDict2, repeatedSettingsDict2);
                _settingsDict2 = _settingsDict2.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
                foreach (var setting in _settingsDict2)
                {
                    dataGridViewSettings2.Rows.Add(setting.Key, setting.Value);
                }
                foreach (var repeatSetting in repeatedSettingsDict2)
                {
                    dataGridViewRepeatedSettings2.Rows.Add(repeatSetting.Key, repeatSetting.Value);
                }
            }
        }
    }
}
