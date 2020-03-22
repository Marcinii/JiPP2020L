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
using KonwerterJednostek2.Logic;

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
                "Odleglość",
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

            if (combobox_Rodzaj_konwersji.SelectedItem == "Odleglość")
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
            if (combobox_Rodzaj_konwersji.SelectedItem == "Temperatura")
            {

                Temperatura_class t1 = new Temperatura_class();
            };

            }

            if (combobox_Rodzaj_konwersji.SelectedItem == "Odleglość")
            {


            }

            if (combobox_Rodzaj_konwersji.SelectedItem == "Masa")
            {


            }

            if (combobox_Rodzaj_konwersji.SelectedItem == "Czas")
            {


            }
        }
    }
}
