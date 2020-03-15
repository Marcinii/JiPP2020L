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
using Konwerter2;

namespace Konwerter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Przycisk_Click(object sender, RoutedEventArgs e)
        {
            string konwerter = Konwerter.Text;

            string zamiana = Zamiana.Text;
            
            string konwersja = Konwersja.Text;

            double wartosc = double.Parse(konwersja);

            double wynik;

            if (konwerter == "Temperatury")
            {
                if(zamiana == "Z Celsjusza na Farenheita")
                {
                    wynik = new CelsjuszaNaFarenheita().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                } else if(zamiana == "Z Farenheita na Celsjusza")
                {
                    wynik = new FarenheitaNaCelsjusza().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                } else
                {
                    MessageBox.Show("Nie wybrałeś poprawnej opcji!");
                }

            } else if (konwerter == "Długości")
            {
                if (zamiana == "Mile na kilometry")
                {
                    wynik = new MileNaKilometry().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                }
                else if (zamiana == "Kilometry na mile")
                {
                    wynik = new KilometryNaMile().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                } else if (zamiana == "Metry na kilometry")
                {
                    wynik = new MetryNaKilometry().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                }
                else
                {
                    MessageBox.Show("Nie wybrałeś poprawnej opcji!");
                }

            } else if (konwerter == "Masy")
            {
                if(zamiana == "Z Kilogramow na Funty") {

                wynik = new KilogramyNaFunty().Convert(wartosc);
                Wynik.Text = wynik.ToString();
                MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                } else if (zamiana == "Z Funtow na Kilogramy")
                {
                    wynik = new FuntyNaKilogramy().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                } else
                {
                    MessageBox.Show("Nie wybrałeś poprawnej opcji!");
                }

            } else if (konwerter == "Czasu")
            {
                if (zamiana == "Z Minut na Sekundy")
                {

                    wynik = new MinutyNaSekundy().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                }
                else if (zamiana == "Z Sekund na Minuty")
                {
                    wynik = new SekundyNaMinuty().Convert(wartosc);
                    Wynik.Text = wynik.ToString();
                    MessageBox.Show("Wynik konwersji: " + Wynik.Text);

                }
                else
                {
                    MessageBox.Show("Nie wybrałeś poprawnej opcji!");
                }

            } else
            {
                MessageBox.Show("Nie wybrałeś poprawnej opcji!");
            }

        }


    }
}
