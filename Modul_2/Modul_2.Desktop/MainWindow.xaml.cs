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

namespace Modul_2.Desktop
{

    public partial class MainWindow : Window
    {
        int x;
        List<Ikonwerter> konwertetr = new List<Ikonwerter>(){
             new Temperatura(),
             new Dlugosc(),
            new Waga(),
             new Czas()
        };
        public MainWindow()
        {
            InitializeComponent();

            converterCombobox.ItemsSource = new ConverterService().GetConverter();

        }

        private void Temp_Click_1(object sender, RoutedEventArgs e)
        {
            Temperatura temp = new Temperatura();
            ListaJednostek.ItemsSource = temp.Unit;
            x = 0;
        }

        private void Waga_Click(object sender, RoutedEventArgs e)
        {
            Waga wight = new Waga();
            ListaJednostek.ItemsSource = wight.Unit;
            x = 1;
        }

        private void Lenght_Click(object sender, RoutedEventArgs e)
        {
            Dlugosc lenght = new Dlugosc();
            ListaJednostek.ItemsSource = lenght.Unit;
            x = 2;
        }

        private void BtTime_Click(object sender, RoutedEventArgs e)
        {
            Czas time = new Czas();
            ListaJednostek.ItemsSource = time.Unit;
            x = 3;

        }

        private void ListaJednostek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputText = inputTextBox.Text;
            double.TryParse(inputText, out double inputValue);

            if (converterCombobox.SelectedIndex < 0)
            {
                double result = konwertetr[x].Zamiana(

                    inputValue, ListaJednostek.SelectedIndex + 1);

                outputTextBlock.Text = result.ToString();
            }
            else
            {
                double result = ((Ikonwerter)converterCombobox.SelectedItem).Zamiana(

                    inputValue, ListaJednostek.SelectedIndex + 1);

                outputTextBlock.Text = result.ToString();

            }
        }

        private void converterCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListaJednostek.ItemsSource = ((Ikonwerter)converterCombobox.SelectedItem).Unit;
        }
    }
}
