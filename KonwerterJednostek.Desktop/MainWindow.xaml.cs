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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Temperatura
            comboboxTempJednZ.ItemsSource = new List<string>()
            {
                "C",
                "F",
                "K"
            };

            comboboxTempJednDo.ItemsSource = new List<string>()
            {
                "C",
                "F",
                "K"
            };

            //Masa
            comboboxMasaJednZ.ItemsSource = new List<string>()
            {
                "f",
                "kg",
                "g"
            };

            comboboxMasaJednDo.ItemsSource = new List<string>()
            {
                "f",
                "kg",
                "g"
            };

            //Dlugosc
            comboboxDlugoscJednZ.ItemsSource = new List<string>()
            {
                "km",
                "m",
                "mm"
            };

            comboboxDlugoscJednDo.ItemsSource = new List<string>()
            {
                "km",
                "m",
                "mm"
            };
            //Litry
            comboboxLitryJednZ.ItemsSource = new List<string>()
            {
                "m^3",
                "l"                
            };

            comboboxLitryJednDo.ItemsSource = new List<string>()
            {
                "m^3",
                "l"
            };
        }

       







        

        private void przyciskKonwersjaTemp_Click(object sender, RoutedEventArgs e)
        {
            KonwerterTemperatura konw = new KonwerterTemperatura();

            string wejscie = textBoxWartoscTemp.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            
            double wynikL = konw.Konwertuj(comboboxTempJednZ.Text, comboboxTempJednDo.Text, wejscieL); 
            textblockWynikTemp.Text = Convert.ToString(wynikL);
        }
        private void przyciskKonwersjaMasa_Click(object sender, RoutedEventArgs e)
        {
            KonwerterMas konw = new KonwerterMas();

            string wejscie = textBoxWartoscMasa.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            double wynikL = konw.Konwertuj(comboboxMasaJednZ.Text, comboboxMasaJednDo.Text, wejscieL);
            textblockWynikMasa.Text = Convert.ToString(wynikL);
        }

        private void przyciskKonwersjaDlugosc_Click(object sender, RoutedEventArgs e)
        {
            KonwerterDlugosc konw = new KonwerterDlugosc();

            string wejscie = textBoxWartoscDlugosc.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            double wynikL = konw.Konwertuj(comboboxDlugoscJednZ.Text, comboboxDlugoscJednDo.Text, wejscieL);
            textblockWynik_Dlugosc.Text = Convert.ToString(wynikL);
        }
        private void przyciskKonwersjaLitry_Click(object sender, RoutedEventArgs e)
        {
            KonwerterLitry konw = new KonwerterLitry();

            string wejscie = textBoxWartoscLitry.Text;
            double wejscieL = Convert.ToDouble(wejscie);
            //MessageBox.Show("Brawo!" + liczba);
            double wynikL = konw.Konwertuj(comboboxLitryJednZ.Text, comboboxLitryJednDo.Text, wejscieL);
            textblockWynik_Litry.Text = Convert.ToString(wynikL);
        }















        private void ComboBoxJednostkaDlugosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxTempJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void comboboxTempJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBoxWartoscMasa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxWartoscDlugosc_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboboxDlugoscJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxMasaJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxDlugoscJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxMasaJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBoxWartoscLitry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboboxLitryJednZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboboxLitryJednDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
