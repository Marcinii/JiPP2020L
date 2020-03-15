using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using unit_converter;

namespace UnitConverterDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, IConverter> AvailableConverters = new ConverterService().GetConverters();
        
        IConverter SelectedConverter { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Unit Converter";
        }

        private void CategoryComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            CategoryComboBox.ItemsSource = AvailableConverters.Keys;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!SourceUnitComboBox.IsEnabled)
            {
                SourceUnitComboBox.IsEnabled = true;
            }
            if (!TargetUnitComboBox.IsEnabled)
            {
                TargetUnitComboBox.IsEnabled = true;
            }

            SelectedConverter = AvailableConverters[CategoryComboBox.SelectedItem.ToString()];
            SourceUnitComboBox.ItemsSource = SelectedConverter.AvailableUnits;
            TargetUnitComboBox.ItemsSource = SelectedConverter.AvailableUnits;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            ResultValueTextBlock.Text = "";

            if (CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select the category!");
            }
            else
            {
                if (SourceUnitComboBox.SelectedItem == null ||
                    TargetUnitComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select units!");
                }
                else
                {
                    string sourceUnit = SourceUnitComboBox.SelectedItem.ToString();
                    string targetUnit = TargetUnitComboBox.SelectedItem.ToString();
                    string inputValue = InputValueTextBox.Text;

                    if (!SelectedConverter.IsInputValid(inputValue, sourceUnit))
                    {
                        MessageBox.Show("Invalid value!");
                    }
                    else
                    {  
                        var result = SelectedConverter.Convert(sourceUnit, targetUnit, inputValue);
                        ResultValueTextBlock.Text = result.ToString();
                    }
                }
            }
        }
    }
}
