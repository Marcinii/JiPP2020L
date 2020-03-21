using KonwerterJednostek;
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
using UnitConverter.Logic;
using LengthConverter = KonwerterJednostek.LengthConverter;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            converterCombobox.ItemsSource = new ConverterService().GetConverters();
        }

        private void ConverterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fromCombobox.ItemsSource =
                ((IConverter)converterCombobox.SelectedItem).Units;
            toCombobox.ItemsSource =
                ((IConverter)converterCombobox.SelectedItem).Units;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextbox.Text;
            double inputValue;
            Double.TryParse(inputText, out inputValue);

            double result = ((IConverter)converterCombobox.SelectedItem).Convert(
                ((IConverter)converterCombobox.SelectedItem).Units
                .IndexOf((string)fromCombobox.SelectedItem),
                ((IConverter)converterCombobox.SelectedItem).Units
                .IndexOf((string)toCombobox.SelectedItem),
                inputValue);                                          

            resultTextblock.Text = result.ToString();
        }
    }
}
