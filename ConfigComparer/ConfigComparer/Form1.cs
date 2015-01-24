using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using ConfigComparer.Properties;

namespace ConfigComparer
{
    public partial class Form1 : Form
    {

        private string _pathToFileOne;
        private string PathToFileOne
        {
            get { return _pathToFileOne; }
            set
            {
                _pathToFileOne = value;
                label2.Text = value;
            }
        }

        private string _pathToFileTwo;
        private string PathToFileTwo
        {
            get { return _pathToFileTwo; }
            set
            {
                _pathToFileTwo = value;
                linkLabel1.Text = value;
            }
        }

        private Settings _settings1;
        private Settings _settings2;

        private readonly List<string> _untouchableSettings;

        public Form1()
        {
            InitializeComponent();
            var untouchableSettings = ConfigurationManager.AppSettings["untouchableSettings"];
            var untouchableSettingsParts = untouchableSettings.Split(',');
            _untouchableSettings = new List<string>();
            foreach (string untouchableSettingsPart in untouchableSettingsParts)
            {
                _untouchableSettings.Add(untouchableSettingsPart.Trim());
            }
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

        private Settings GetSettingsDict(string pathToFile)
        {
            var doc = XDocument.Load(pathToFile);
            return GetSettingsDict(doc);
        }

        private void selectFirstSettingsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathToFileOne = openFileDialog1.FileName;
                var doc = XDocument.Load(PathToFileOne);
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
            foreach (DataGridViewRow row in gridForSettings.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
            //gridForSettings.Rows[0].Cells[0].Style.BackColor = Color.Aquamarine;
        }

        private void selectSecondSettingsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PathToFileTwo = openFileDialog1.FileName;
                var doc = XDocument.Load(PathToFileTwo);
                _settings2 = GetSettingsDict(doc);
                FillSettingsGrids(dataGridViewSettings2, dataGridViewRepeatedSettings2, _settings2);
            }
        }

        private void fromOneToTwoFileButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> mainSettings;
            var sel = dataGridViewSettings1.SelectedRows;
            if (sel.Count != 0)
            {
                mainSettings = new Dictionary<string, string>();
                foreach (DataGridViewRow dataGridViewRow in sel)
                {
                    mainSettings.Add(dataGridViewRow.Cells[0].Value.ToString(),
                        dataGridViewRow.Cells[1].Value.ToString());
                }
            }
            else
            {
                mainSettings = _settings1.MainSettings;
            }
            if (mainSettings == null)
            {
                MessageBox.Show(Resources.firstSettingsFileNotSelect);
                return;
            }
            if (_settings2.MainSettings == null)
            {
                MessageBox.Show(Resources.SecondSettingsFileNotSelected);
                return;
            }
            var settingsDiff = GetSettingsDifferent(mainSettings, _settings2.MainSettings);
            Dictionary<string, string> notExistSettings = settingsDiff.ToDictionary(o => o.Key, o => o.Value);
            var doc = XDocument.Load(PathToFileTwo);
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
            doc.Save(PathToFileTwo);
            _settings2 = GetSettingsDict(doc);
            FillSettingsGrids(dataGridViewSettings2, dataGridViewRepeatedSettings2, _settings2);
        }

        private Dictionary<string, string> GetSettingsDifferent(Dictionary<string, string> mainSettings1, Dictionary<string, string> mainSettings2)
        {
            var settingsDiff = new Dictionary<string, string>();
            foreach (var setting in mainSettings1)
            {
                if (mainSettings2.ContainsKey(setting.Key))
                {
                    string value;
                    if (mainSettings2.TryGetValue(setting.Key, out value))
                    {
                        if (value != setting.Value)
                        {
                            settingsDiff.Add(setting.Key, setting.Value);
                        }
                    }
                }
                else
                {
                    settingsDiff.Add(setting.Key, setting.Value);
                }
            }
            return settingsDiff;
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

        private void refreshSettings1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PathToFileOne))
            {
                _settings1 = GetSettingsDict(PathToFileOne);
                FillSettingsGrids(dataGridViewSettings1, dataGridViewRepeatedSettings1, _settings1);
            }
            else
            {
                MessageBox.Show(Resources.needSelectSettingsFile, Resources.settingsFileNotSelected,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void refreshSettings2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PathToFileTwo))
            {
                _settings2 = GetSettingsDict(PathToFileTwo);
                FillSettingsGrids(dataGridViewSettings2, dataGridViewRepeatedSettings2, _settings2);
            }
            else
            {
                MessageBox.Show(Resources.needSelectSettingsFile, Resources.settingsFileNotSelected,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void highlightDifferentSettingsButton_Click(object sender, EventArgs e)
        {
            var diffSettings = GetSettingsDifferent(_settings1.MainSettings, _settings2.MainSettings);
            foreach (DataGridViewRow row in dataGridViewSettings1.Rows)
            {
                var settingName = row.Cells[0].Value == null ? string.Empty : row.Cells[0].Value.ToString();
                if (diffSettings.ContainsKey(settingName))
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.Aquamarine;
                    }
                }
            }
        }
    }
}
