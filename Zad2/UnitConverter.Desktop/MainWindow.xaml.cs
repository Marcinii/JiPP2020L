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
using Konwerter_console;

namespace UnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Iconverter> converters = new List<Iconverter>()
            {
                new CelToFar(),
                new FarToCel(),
                new KgToFu(),
                new FuToKg(),
                new KmToMi(),
                new MiToKm(),
                new MeToKm(),
                new MinToSec(),
                new SecToMin()
            };

            ComboboxConv.ItemsSource = new List<Iconverter>
            {
                new CelToFar(),
                new FarToCel(),
                new KgToFu(),
                new FuToKg(),
                new KmToMi(),
                new MiToKm(),
                new MeToKm(),
                new MinToSec(),
                new SecToMin()
        };
        }

        private void ComboboxConv_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LabelFrom.Content = ((Iconverter)ComboboxConv.SelectedItem).unitFrom;
            LabelTo.Content = ((Iconverter)ComboboxConv.SelectedItem).unitTo;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = InputTextBox.Text;
            double inputValue = double.Parse(inputText);

            double result = ((Iconverter)ComboboxConv.SelectedItem).Convert(inputValue);

            outputTextBlock.Text = result.ToString();
        }
    }
}
