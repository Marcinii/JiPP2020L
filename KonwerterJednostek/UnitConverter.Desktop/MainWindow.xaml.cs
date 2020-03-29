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
            clockRotation.Angle = 100;
        }

        private void ConverterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItemName = ((IConverter)converterCombobox.SelectedItem).Name.ToString();
            if (selectedItemName.Equals("Czas"))
            {
                ((Storyboard)Resources["clockVisibility"]).Begin();
            }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["circleStoryboard"]).Begin();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["circleStoryboard"]).Stop();
        }
    }
}
