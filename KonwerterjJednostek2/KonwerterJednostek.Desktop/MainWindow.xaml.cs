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
using KonwerterjJednostek2;

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

            combobox_Rodzaj_konwersji.ItemsSource = new List<string>()
            {
                "Temperatura",
                "Odleglosc",
                "Masa",
                "Czas"     
            };



        }

        private void combobox_Rodzaj_konwersji_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (combobox_Rodzaj_konwersji.SelectedItem == "Temperatura")
            {
                combobox_Jednostka_bazowa.ItemsSource = new List<string>()
                {
                    "C",
                    "F",
                    "K"
                };

                combobox_Jednostka_wynikowa.ItemsSource = new List<string>()
                {
                    "C",
                    "F",
                    "K"
                };

            }

            if (combobox_Rodzaj_konwersji.SelectedItem == "Odleglosc")
            {
                combobox_Jednostka_bazowa.ItemsSource = new List<string>()
                {
                    "M",
                    "KM",
                    "MI"
                };

                combobox_Jednostka_wynikowa.ItemsSource = new List<string>()
                {
                    "M",
                    "KM",
                    "MI"
                };

            }

            if (combobox_Rodzaj_konwersji.SelectedItem == "Masa")
            {
                combobox_Jednostka_bazowa.ItemsSource = new List<string>()
                {
                    "G",
                    "KG",
                    "F"
                };

                combobox_Jednostka_wynikowa.ItemsSource = new List<string>()
                {
                    "G",
                    "KG",
                    "F"
                };

            }

            if (combobox_Rodzaj_konwersji.SelectedItem == "Czas")
            {
                combobox_Jednostka_bazowa.ItemsSource = new List<string>()
                {
                    "G",
                    "M",
                    "S"
                };

                combobox_Jednostka_wynikowa.ItemsSource = new List<string>()
                {
                    "G",
                    "M",
                    "S"
                };

            }


        }

        private void button_action_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(textbox_input.Text, out double wartosc);
            double wynik = 0;
            

            if (combobox_Rodzaj_konwersji.Text == "Temperatura")
            {
                Temperatura_class t1 = new Temperatura_class();
                wynik = t1.Konwerter(combobox_Jednostka_bazowa.Text, combobox_Jednostka_wynikowa.Text, wartosc);
                textbox_wynik.Text = wynik.ToString("0.00");
            };
            
            if (combobox_Rodzaj_konwersji.Text == "Odleglosc")
            {
                Odleglosc_class t1 = new Odleglosc_class();
                wynik = t1.Konwerter(combobox_Jednostka_bazowa.Text, combobox_Jednostka_wynikowa.Text, wartosc);
                textbox_wynik.Text = wartosc.ToString("0.00");
            };

            if (combobox_Rodzaj_konwersji.Text == "Masa")
            {
                Masa_class t1 = new Masa_class();
                wynik = t1.Konwerter(combobox_Jednostka_bazowa.Text, combobox_Jednostka_wynikowa.Text, wartosc);
                textbox_wynik.Text = wartosc.ToString("0.00");
            };

            if (combobox_Rodzaj_konwersji.Text == "Czas")
            {
                Czas_class t1 = new Czas_class();
                wynik = t1.Konwerter(combobox_Jednostka_bazowa.Text, combobox_Jednostka_wynikowa.Text, wartosc);
                textbox_wynik.Text = wartosc.ToString("0.00");
            };
        }
    }
}
