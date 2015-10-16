using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using Microsoft.Win32;

namespace ConfigComparerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _firstFilePath;
        private string _secondFilePath;
        private Dictionary<string, string> _firstSettings;
        private Dictionary<string, string> _secondSettings;

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

        public MainWindow()
        {
            InitializeComponent();
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

        private void FillSettingsGrid(DataGrid dataGrid, Dictionary<string, string> settings)
        {
            dataGrid.ItemsSource = settings;
        }

        private Dictionary<string, string> GetSettings(string filePath)
        {
            var xmlFile = XDocument.Load(filePath);
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
                .ToDictionary(settingsElement => settingsElement.Attribute("key").Value, settingsElement => settingsElement.Attribute("value").Value);
        }

        private string SelectFileDialog()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            var dialogResult = openFileDialog.ShowDialog(this);
            if (dialogResult.Value)
            {
                return openFileDialog.FileName;
            }
            return "Файл не выбран";
        }

        private void CompareButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
