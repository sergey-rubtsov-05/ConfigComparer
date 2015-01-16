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

        XDocument doc1;
        private XDocument doc2;

        private string fileName2;

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
                            //element.Attribute("value").Value = "Check2";
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
                doc1 = XDocument.Load(openFileDialog1.FileName);
                GetSettingsDict(doc1, _settingsDict1, repeatedSettingsDict1);
                doc1.Save(openFileDialog1.FileName);
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
                fileName2 = openFileDialog1.FileName;
                doc2 = XDocument.Load(fileName2);
                GetSettingsDict(doc2, _settingsDict2, repeatedSettingsDict2);
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

        private void button1_Click(object sender, EventArgs e)
        {
            var settingsDiff = new Dictionary<string, string>();
            foreach (var setting in _settingsDict1)
            {
                if (_settingsDict2.ContainsKey(setting.Key))
                {
                    string value;
                    if (_settingsDict2.TryGetValue(setting.Key, out value))
                    {
                        if (value != setting.Value)
                            settingsDiff.Add(setting.Key, setting.Value);
                    }
                }
                else
                {
                    settingsDiff.Add(setting.Key, setting.Value);
                }
            }
            if (doc2.Root != null)
                foreach (var xElement in doc2.Root.Elements())
                {
                    if (xElement.Name == ("appSettings"))
                    {
                        foreach (var element in xElement.Elements())
                        {
                            foreach (var setting in settingsDiff)
                            {
                                if (element.Attribute("key").Value == setting.Key)
                                {
                                    element.Attribute("value").SetValue(setting.Value);
                                }
                            }
                        }
                    }
                }
            doc2.Save(fileName2);
        }
    }
}
