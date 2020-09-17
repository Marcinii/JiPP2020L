using KonwerterJednostek.Logic;
using System;
using System.Collections.Generic;
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

namespace KonwerterJednostek.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            converterComboBox.ItemsSource = new ConverterService().GetConverters();

        }
        
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            string unitFrom = unitFromCombobox.Text;
            string unitTo = unitToCombobox.Text;
            if (decimal.TryParse(inputTextBox.Text, out decimal value) && !String.IsNullOrEmpty(unitFrom) && !String.IsNullOrEmpty(unitTo))
            {
                outputTextBlock.Text = ((IConverter)converterComboBox.SelectedItem).Convert(unitFrom, unitTo, value) + unitTo.ToUpperInvariant();
            }
            else if (String.IsNullOrEmpty(unitFrom) || String.IsNullOrEmpty(unitTo))
            {
                MessageBox.Show("Wprowadź poprawne jednostki.", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne wartości.", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void converterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
        }

        private void timeConverterButton_Click(object sender, RoutedEventArgs e)
        {
            if(timeConverterTextBox.Text.Length == 5)
            {
                string res = new TimeConverter().Convert(timeConverterTextBox.Text);
                timeConverterResult.Text = res;
            }
            else
            {
                MessageBox.Show("Format godziny powinien wyglądać XX:XX", null, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void timeConverterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(timeConverterTextBox.Text.Length == 5)
            {
                int hours = new TimeConverter().GetHour(timeConverterTextBox.Text);
                int mins = new TimeConverter().GetMinute(timeConverterTextBox.Text);
                Console.WriteLine(((double)hours * 30d) + ((double)mins * 0.5d) + 90d);
                if( clockRotation != null)
                {
                    clockRotation.Angle = ((double)hours * 30d) + ((double)mins * 0.5d) + 90d;
                }
            }
        }
    }
}
