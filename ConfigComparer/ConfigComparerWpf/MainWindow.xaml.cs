using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using Microsoft.Win32;

namespace ConfigComparerWpf
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<string> _differentSettings = new List<string>();
        private string _firstFilePath;
        private List<KeyValuePair<string, string>> _firstSettings;
        private List<string> _missingSettings = new List<string>();
        private string _secondFilePath;
        private List<KeyValuePair<string, string>> _secondSettings;

        public MainWindow()
        {
            InitializeComponent();
        }

        private string FirstFilePath
        {
            get { return _firstFilePath; }
            set
            {
                FirstFilePathLabel.Content = value;
                _firstFilePath = value;
            }
        }

        private string SecondFilePath
        {
            get { return _secondFilePath; }
            set
            {
                SecondFilePathLabel.Content = value;
                _secondFilePath = value;
            }
        }

        private void FirstFileSelectButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = SelectFileDialog();
            FirstFilePath = filePath;
            _firstSettings = GetSettings(FirstFilePath);
            FillSettingsGrid(FirstDataGrid, _firstSettings);
        }

        private void SecondFileSelectButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = SelectFileDialog();
            SecondFilePath = filePath;
            _secondSettings = GetSettings(SecondFilePath);
            FillSettingsGrid(SecondDataGrid, _secondSettings);
        }

        private void FillSettingsGrid(DataGrid dataGrid, List<KeyValuePair<string, string>> settings)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = settings;
        }

        private List<KeyValuePair<string, string>> GetSettings(string filePath)
        {
            XDocument xmlFile;
            try
            {
                xmlFile = XDocument.Load(filePath);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не выбран");
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ошибка при загрузке файла настроек:
{e.Message}");
                return null;
            }
            if (xmlFile.Root == null)
            {
                MessageBox.Show("Файл не подходящего формата");
                return null;
            }

            return xmlFile
                .Root
                .Elements("appSettings")
                .Elements()
                .OrderBy(settingsElement => settingsElement.Attribute("key").Value)
                .Select(
                    element =>
                        new KeyValuePair<string, string>(element.Attribute("key").Value,
                            element.Attribute("value").Value))
                .ToList();
        }

        private string SelectFileDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Config Files|*.config|All Files|*.*"
            };
            var dialogResult = openFileDialog.ShowDialog(this);
            if (dialogResult.Value)
            {
                return openFileDialog.FileName;
            }
            return "Файл не выбран";
        }

        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {
            CompareSettings(_firstSettings, _secondSettings);
        }

        private void CompareSettings(List<KeyValuePair<string, string>> firstSettings,
            List<KeyValuePair<string, string>> secondSettings)
        {
            if (firstSettings == null) return;
            if (secondSettings == null) return;

            _differentSettings = new List<string>();
            _missingSettings = new List<string>();

            foreach (var firstSetting in firstSettings)
            {
                if (secondSettings.ContainsKey(firstSetting.Key))
                {
                    if (!secondSettings.GetValueByKey(firstSetting.Key).Equals(firstSetting.Value))
                    {
                        _differentSettings.Add(firstSetting.Key);
                    }
                }
                else
                {
                    _missingSettings.Add(firstSetting.Key);
                }
            }

            var comparedSettings = new List<KeyValuePair<string, string>>();
            foreach (var setting in firstSettings)
            {
                if (_missingSettings.Contains(setting.Key))
                {
                    comparedSettings.Add(new KeyValuePair<string, string>("", ""));
                    continue;
                }
                comparedSettings.Add(new KeyValuePair<string, string>(setting.Key,
                    secondSettings.GetValueByKey(setting.Key)));
            }
            foreach (var secondSetting in secondSettings)
            {
                if (!comparedSettings.ContainsKey(secondSetting.Key))
                    comparedSettings.Add(secondSetting);
            }
            FillSettingsGrid(FirstDataGrid, _firstSettings);
            FillSettingsGrid(SecondDataGrid, comparedSettings);
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var row = (KeyValuePair<string, string>) e.Row.DataContext;
            if (_missingSettings.Contains(row.Key) || string.IsNullOrEmpty(row.Key))
            {
                e.Row.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else if (_differentSettings.Contains(row.Key))
            {
                e.Row.Background = new SolidColorBrush(Colors.Aquamarine);
            }
            else
            {
                e.Row.Background = new SolidColorBrush(Colors.White);
            }
        }
    }

    public static class Extensions
    {
        public static bool ContainsKey(this List<KeyValuePair<string, string>> list, string key)
        {
            return list.Any(keyValuePair => keyValuePair.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
        }

        public static string GetValueByKey(this List<KeyValuePair<string, string>> list, string key)
        {
            foreach (var keyValuePair in list)
            {
                if (keyValuePair.Key.Equals(key, StringComparison.OrdinalIgnoreCase))
                    return keyValuePair.Value;
            }
            throw new ArgumentOutOfRangeException(nameof(key), @"Нет элемента с таким ключом");
        }
    }
}