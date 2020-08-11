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

namespace Converter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            converterComboBox.ItemsSource = new List<IConverter>()
            {
                new LenghtConverter(),
                new TemperatureConverter(),
                new QuantityConverter(),
                new WeightConverter()
            };
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromComboBox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
            unitToComboBox.ItemsSource = ((IConverter)converterComboBox.SelectedItem).Units;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            decimal inputValue = decimal.Parse(inputText);

            decimal result = ((IConverter)converterComboBox.SelectedItem).Convert(
                unitFromComboBox.SelectedItem.ToString(),
                unitToComboBox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();
        }

   
    }
}
