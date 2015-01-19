using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ConfigComparer.Properties;

namespace ConfigComparer
{
    public partial class Form1 : Form
    {

        private string _pathToFileOne;
        private string _pathToFileTwo;

        private Settings _settings1;
        private Settings _settings2;

        private readonly List<string> _untouchableSettings; 

        public Form1()
        {
            InitializeComponent();
            _untouchableSettings = new List<string> {"Key1", "Key2"};
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var untouchableSetting in _untouchableSettings)
            {
                listBox1.Items.Add(untouchableSetting);
            }
        }

        private Settings GetSettingsDict(XDocument doc)
        {
            var settings = new Settings
            {
                MainSettings = new Dictionary<string, string>(),
                RepeatedSettings = new Dictionary<string, string>()
            };
            _untouchableSettings.Clear();
            foreach (var item in listBox1.Items)
            {
                _untouchableSettings.Add(item.ToString());
            }
            if (doc.Root != null)
                foreach (var xElement in doc.Root.Elements())
                {
                    if (xElement.Name == ("appSettings"))
                    {
                        foreach (var element in xElement.Elements())
                        {
                            try
                            {
                                if (!_untouchableSettings.Contains(element.Attribute("key").Value))
                                    settings.MainSettings.Add(element.Attribute("key").Value, element.Attribute("value").Value);
                            }
                            catch (ArgumentException)
                            {
                                settings.RepeatedSettings.Add(element.Attribute("key").Value, element.Attribute("value").Value);
                            }
                        }
                    }
                }
            return settings;
        }

        private void selectFirstSettingsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _pathToFileOne = openFileDialog1.FileName;
                var doc = XDocument.Load(_pathToFileOne);
                _settings1 = GetSettingsDict(doc);
                FillSettingsGrids(dataGridViewSettings1, dataGridViewRepeatedSettings1, _settings1);
            }
        }

        private void FillSettingsGrids(DataGridView gridForSettings, DataGridView gridForRepeatedSettings, Settings settings)
        {
            gridForSettings.Rows.Clear();
            gridForRepeatedSettings.Rows.Clear();
            settings.MainSettings = settings.MainSettings.OrderBy(o => o.Key).ToDictionary(o => o.Key, o => o.Value);
            foreach (var setting in settings.MainSettings)
            {
                gridForSettings.Rows.Add(setting.Key, setting.Value);
            }
            foreach (var repeatSetting in settings.RepeatedSettings)
            {
                gridForRepeatedSettings.Rows.Add(repeatSetting.Key, repeatSetting.Value);
            }
        }

        private void selectSecondSettingsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _pathToFileTwo = openFileDialog1.FileName;
                var doc = XDocument.Load(_pathToFileTwo);
                _settings2 = GetSettingsDict(doc);
                FillSettingsGrids(dataGridViewSettings2, dataGridViewRepeatedSettings2, _settings2);
            }
        }

        private void fromOneToTwoFileButton_Click(object sender, EventArgs e)
        {
            var settingsDiff = new Dictionary<string, string>();
            var notExistSettings = new Dictionary<string, string>();
            if (_settings1.MainSettings == null)
            {
                MessageBox.Show(Resources.firstSettingsFileNotSelect);
                return;
            }
            foreach (var setting in _settings1.MainSettings)
            {
                if (_settings2.MainSettings.ContainsKey(setting.Key))
                {
                    string value;
                    if (_settings2.MainSettings.TryGetValue(setting.Key, out value))
                    {
                        if (value != setting.Value)
                        {
                            settingsDiff.Add(setting.Key, setting.Value);
                            notExistSettings.Add(setting.Key, setting.Value);
                        }
                    }
                }
                else
                {
                    settingsDiff.Add(setting.Key, setting.Value);
                    notExistSettings.Add(setting.Key, setting.Value);
                }
            }
            var doc = XDocument.Load(_pathToFileTwo);
            if (doc.Root != null)
                foreach (var xElement in doc.Root.Elements())
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
                                    notExistSettings.Remove(setting.Key);
                                }
                            }
                        }
                        foreach (var setting in notExistSettings)
                        {
                            xElement.Add(new XElement("add", new XAttribute("key", setting.Key),
                                new XAttribute("value", setting.Value)));
                        }
                    }
                }
            doc.Save(_pathToFileTwo);
            _settings2 = GetSettingsDict(doc);
            FillSettingsGrids(dataGridViewSettings2, dataGridViewRepeatedSettings2, _settings2);
        }
        private struct Settings
        {
            public Dictionary<string, string> MainSettings;
            public Dictionary<string, string> RepeatedSettings;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Add(textBox1.Text);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}
