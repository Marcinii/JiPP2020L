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


        private void przyciskCzymJestem_Click(object sender, RoutedEventArgs e)
        {

            labelIntro1.Foreground = Brushes.DarkGoldenrod;
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


        private void buttonKonwertujGodzine_Click(object sender, RoutedEventArgs e)
        {
            KonwerterGodzina konw = new KonwerterGodzina();

            string wejscieH = textboxGodzina24.Text;
            int wejscieL = Convert.ToInt32(wejscieH);

            string wejscieMIN = textboxMinuty24.Text;
            double wejscieK = Convert.ToDouble(wejscieMIN);

            if (wejscieL >= 12)
                textboxMinutySUFIKS.Text = "PM";
            else
                textboxMinutySUFIKS.Text = "AM";

            int wynikL = konw.Konwertuj(wejscieL);

            textboxGodzina12.Text = Convert.ToString(wynikL);
            textboxMinuty12.Text = Convert.ToString(wejscieK);


            //mechanizm obracajacy wskazowka godziny
            wskazowka1.Angle = 0;
            wskazowka2.Angle = 0;

            for (int i = 0; i < wynikL; i++)
                wskazowka1.Angle += 30;

            wskazowka1.Angle -= 90;

            //mechanizm obracajacy wskazowka minut
            wskazowka2.Angle = 0;

            for (int i = 0; i < wejscieK; i++)
                wskazowka2.Angle += 6;

            wskazowka2.Angle -= 90;
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
