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
using ZAD3;

namespace ZAD3.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            RodzajKonwertera.ItemsSource = new List<IProgram>()
            {

                new Masa(),
                new Odleglosc(),
                new Temperatura(),
                new Objetosc()
            };
            Czy12h.ItemsSource = new List<string>()
            {
                "12h",
                "24h"
            };
            Minuty.ItemsSource = new List<int>()
            {
                0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,
                31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59
            };
            

        }
        private void RodzajKonwertera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            JednostkaZ.ItemsSource = ((IProgram)RodzajKonwertera.SelectedItem).j_;
            JednostkaDo.ItemsSource = ((IProgram)RodzajKonwertera.SelectedItem).j_;
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string DaneText = DaneWpisz.Text;
            double DaneLiczba = double.Parse(DaneText);

            double wynikLiczba = ((IProgram)RodzajKonwertera.SelectedItem).Konwersja(
                JednostkaZ.SelectedItem.ToString(),
                JednostkaDo.SelectedItem.ToString(),
                DaneLiczba);
            WynikText.Text = wynikLiczba.ToString();

        }

        public void Czy12h_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool CzyAM = true;
            bool Czy24h = true;
            int h = 0;
            int min = 0;
            h= Godziny.SelectedIndex;
            min =Minuty.SelectedIndex;
            if (Czy12h.SelectedItem=="12h")
            {
                Godziny.ItemsSource = new List<int>()
                {
                1,2,3,4,5,6,7,8,9,10,11,12
                };
                Czy24h = false;
            }
            else if(Czy12h.SelectedItem == "24h")
            {
                Godziny.ItemsSource = new List<int>()
                {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24
                };
                Czy24h = true;
            }

            if(Czy12h.SelectedItem == "12h")
            {
                AMPM.ItemsSource = new List<string>()
                {
                    "AM",
                    "PM"
                };
                Czy24h = false;
            }
            else
            {
                AMPM.ItemsSource = new List<string>()
                {};
            }

            if (AMPM.SelectedItem == "PM")
            {
                CzyAM = false;
            }
            else if (AMPM.SelectedItem == "AM")
            {
                CzyAM = true;
            }
            Czas Wynik = new Czas();

            double pomocniczy = Wynik.Z24hna12h(h,min,CzyAM,Czy24h);
            int mm = (int)((pomocniczy * 100) % 100);
            int hh = (int)((pomocniczy) % 100);
            if (h > 12 && Czy24h==true)
            {
                if (mm < 10)
                {

                    Wyswietlacz.Text = hh.ToString() + ":" + "0" + mm.ToString() + " PM";
                }
                else
                {
                    Wyswietlacz.Text = hh.ToString() + ":" + mm.ToString() + " PM";
                }
            }
            else if(h <= 12 && Czy24h == true)
            {
                if (mm < 10)
                {

                    Wyswietlacz.Text = hh.ToString() + ":" + "0" + mm.ToString() + " AM";
                }
                else
                {
                    Wyswietlacz.Text = hh.ToString() + ":" + mm.ToString() + " AM";
                }
            }
            else
            {
                if (mm < 10)
                {

                    Wyswietlacz.Text = hh.ToString() + ":" + "0" + mm.ToString();
                }
                else
                {
                    Wyswietlacz.Text = hh.ToString() + ":" + mm.ToString();
                }
            }
           
            GodzinowaObrot.Angle = 0;
            MinutowaObrot.Angle = 0;

            GodzinowaObrot.Angle = ((hh + 3) * 30);
            MinutowaObrot.Angle = (mm + 15) * 6;
        }
    }
}