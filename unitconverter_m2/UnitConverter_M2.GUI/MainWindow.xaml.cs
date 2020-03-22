using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace UnitConverter_M2.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void przelicz0_Click(object sender, RoutedEventArgs e)
        {
            decimal temp;
            LengthConv lc = new LengthConv();
            temp = lc.convert(przelicz00.Text, przelicz01.Text, Decimal.Parse(wartosc0.Text, NumberStyles.Any, CultureInfo.InvariantCulture));
            wynik0.Content = temp.ToString();
        }

        private void przelicz1_Click(object sender, RoutedEventArgs e)
        {
            decimal temp;
            MassConv lc = new MassConv();
            temp = lc.convert(przelicz10.Text, przelicz11.Text, Decimal.Parse(wartosc1.Text, NumberStyles.Any, CultureInfo.InvariantCulture));
            wynik1.Content = temp.ToString();
        }

        private void przelicz2_Click(object sender, RoutedEventArgs e)
        {
            decimal temp;
            PowerConv lc = new PowerConv();
            temp = lc.convert(przelicz20.Text, przelicz21.Text, Decimal.Parse(wartosc2.Text, NumberStyles.Any, CultureInfo.InvariantCulture));
            wynik2.Content = temp.ToString();
        }

        private void przelicz3_Click(object sender, RoutedEventArgs e)
        {
            decimal temp;
            TemperatureConv lc = new TemperatureConv();
            temp = lc.convert(przelicz30.Text, przelicz31.Text, Decimal.Parse(wartosc3.Text, NumberStyles.Any, CultureInfo.InvariantCulture));
            wynik3.Content = temp.ToString();
        }
    }
}
