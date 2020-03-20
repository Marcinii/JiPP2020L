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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnitConverter.Logic;

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

        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitFromCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
            unitToCombobox.ItemsSource = ((IConverter)converterCombobox.SelectedItem).Units;
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            double inputValue = double.Parse(inputText);

            double result = ((IConverter)converterCombobox.SelectedItem).Convert(
                unitFromCombobox.SelectedItem.ToString(),
                unitToCombobox.SelectedItem.ToString(),
                inputValue);

            outputTextBlock.Text = result.ToString();
        }
    }
}
