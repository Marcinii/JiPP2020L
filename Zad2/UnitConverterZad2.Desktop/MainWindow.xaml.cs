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

namespace UnitConverterZad2.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IConverter> converters = new List<IConverter>()
            {
                new LengthConverter(),
                new TemperatureConverter(),
                new MassConverter(),
                new PowerConverter()
            };

        List<string> convertersName = new List<string>()
            {
                new LengthConverter().Name,
                new TemperatureConverter().Name,
                new MassConverter().Name,
                new PowerConverter().Name
            };

        public MainWindow()
        {
            InitializeComponent();

            conventersComboBox.ItemsSource = convertersName;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            decimal value;
            if (decimal.TryParse(ValueTextBox.Text, out value))
            {
                string unitFrom = unitFromComboBox.Text;
                string unitTo = unitToComboBox.Text;
                decimal valueAfterConversion = converters[conventersComboBox.SelectedIndex].Convert(unitFrom, unitTo, value);
                textBlock.Text = valueAfterConversion.ToString();
            }
            else
                MessageBox.Show("Wprowadź liczbę do konwersji");
        }

        private void conventersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromComboBox.IsEnabled = true;
            unitToComboBox.IsEnabled = true;
            unitFromComboBox.ItemsSource = converters[conventersComboBox.SelectedIndex].Units;
            unitToComboBox.ItemsSource = converters[conventersComboBox.SelectedIndex].Units;
        }
    }
}
