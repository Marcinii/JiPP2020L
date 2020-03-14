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

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<IConverter> converters = new List<IConverter>
            {
                new TempConverter(),
                new WeightConverter(),
                new LengthConverter(),
                new TimeConverter(),
                new CapacityConverter()
            };

            ConverterListComboBox.ItemsSource = converters;
            ConverterListComboBox.DisplayMemberPath = "Name";

            ConverterListComboBox.SelectedIndex = 0;

        }

        private void ConverterListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ConvertFromListComboBox.ItemsSource = ((IConverter)ConverterListComboBox.SelectedItem).Units;
            ConvertToListComboBox.ItemsSource = ((IConverter)ConverterListComboBox.SelectedItem).Units;
            ConvertFromListComboBox.SelectedIndex = 0;
            ConvertToListComboBox.SelectedIndex = 1;
            Recalculate();

        }


        private void Recalculate()
        {
            try
            {
                ResultTextBlock.Text = string.Empty;
                string result = ValueToConvertTextBlock.Text + " " + ConvertFromListComboBox.SelectedValue + " = ";
                result += ((IConverter)ConverterListComboBox.SelectedItem)
                     .Convert(
                        (string)ConvertFromListComboBox.SelectedValue,
                        (string)ConvertToListComboBox.SelectedValue,
                        Double.Parse(ValueToConvertTextBlock.Text)).ToString();
                result += " " + ConvertToListComboBox.SelectedValue;
                ResultTextBlock.Text = result;

            }
            catch (FormatException)
            {
                ResultTextBlock.Text = string.Empty;
            }
        }

        private void ValueToConvertTextBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            Recalculate();
        }

        private void ConvertFromListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recalculate();
        }

        private void ConvertToListComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recalculate();
        }
    }
}
