using Przelicznik.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Przeliczniki.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        PrzelicznikI obecnyPrzelicznik;
        bool czyPrzelicznikCzasu = false;
        string jednostkaZ, jednostkaDo;
        int obecnaStrona = 1;

        List<PrzelicznikI> Przeliczniki = new List<PrzelicznikI>
        {
            new Czasu(),
            new Długości(),
            new Prędkość(),
            new Temperatury(),
            new Masa(),
        };

        List<string> Nazwy = new List<string> { };


        public MainWindow()
        {
            InitializeComponent();
            WyborPrzelicznikComboBox.ItemsSource = Przeliczniki;
            foreach (PrzelicznikI p in Przeliczniki)
            {
                Nazwy.Add(p.Name);
            }

            KonwerterStatystykiWybor.ItemsSource = Nazwy;

        }

        private void WyborPrzelicznikComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((PrzelicznikI)WyborPrzelicznikComboBox.SelectedItem).Name == "Przelicznik czasu")
            {
                czyPrzelicznikCzasu = true;
                ZegarUklad.Visibility = Visibility.Visible;
                var animacja = (Storyboard)FindResource("ZegarPokaz");
                animacja.Begin();
            }
            else
            {
                czyPrzelicznikCzasu = false;
                ZegarUklad.Visibility = Visibility.Hidden;
            }

            obecnyPrzelicznik = (PrzelicznikI)WyborPrzelicznikComboBox.SelectedItem;

            WyborJednostkaWejscComboBox.ItemsSource = obecnyPrzelicznik.jednostka;
            WyborJednostkaWyjscComboBox.ItemsSource = obecnyPrzelicznik.jednostka;
        }

        private void WyborJednostkaWyjscComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WyborJednostkaWyjscComboBox.SelectedItem != null)
            {
                jednostkaDo = WyborJednostkaWyjscComboBox.SelectedItem.ToString();
            }
        }

        private void ObliczPrzycisk_Click(object sender, RoutedEventArgs e)
        {
            if (czyPrzelicznikCzasu && PoleWejsciowe.Text != "")
            {
                PoleWyjsciowe.Text = obecnyPrzelicznik.przeliczCzas(PoleWejsciowe.Text);
                var wartosc = "";
                if (PoleWejsciowe.Text.Split(' ').Length == 2)
                {
                    wartosc = PoleWejsciowe.Text.Split(' ')[0];
                }
                else
                {
                    wartosc = PoleWejsciowe.Text;
                }

                RotateTransform obrot = new RotateTransform(int.Parse(wartosc) * 30);
                WskazowkaSciezka.RenderTransform = obrot;
            }
            else
            {
                if (jednostkaZ != "" && jednostkaDo != "" && PoleWejsciowe.Text != "")
                {
                    var wyjscie = obecnyPrzelicznik.przelicz(jednostkaZ, jednostkaDo, Double.Parse(PoleWejsciowe.Text));
                    PoleWyjsciowe.Text = wyjscie.ToString() + " " + jednostkaDo;
                    ZapiszWynikDoBazy(Double.Parse(PoleWejsciowe.Text), wyjscie, obecnyPrzelicznik.Name, jednostkaZ, jednostkaDo);
                }
            }
        }

        private void WyborJednostkaWejscComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WyborJednostkaWejscComboBox.SelectedItem != null)
            {
                jednostkaZ = WyborJednostkaWejscComboBox.SelectedItem.ToString();
            }
        }

        private void ZapiszWynikDoBazy(double wartosc, double wynik, string konwerter, string jednostkaZ, string jednostkaDo)
        {
            try
            {
                using (var baza = new PrzelicznikPrzeliczenia())
                {
                    baza.Przeliczenias.Add(new Przeliczenia
                    {
                        konwerter = konwerter,
                        wartosc = wartosc,
                        data = DateTime.Now,
                        jednostkaZ = jednostkaZ,
                        jednostkaDo = jednostkaDo,
                        wynik = wynik,
                    });
                    baza.SaveChanges();
                }
            }
            catch (Exception e)
            {
                PoleWyjsciowe.Text = e.Message;
            }
        }

        private void WybierzPrzycisk_Click(object sender, RoutedEventArgs e)
        {
            WczytajStatystyki();
        }

        private void StronaMinus_Click(object sender, RoutedEventArgs e)
        {
            if (obecnaStrona != 1)
            {
                obecnaStrona = obecnaStrona - 1;
                KtoraStrona.Content = (int.Parse(KtoraStrona.Content.ToString()) - 1).ToString();
            }
            WczytajStatystyki();
        }

        private void StronaPlus_Click(object sender, RoutedEventArgs e)
        {
            obecnaStrona = obecnaStrona + 1;
            KtoraStrona.Content = (int.Parse(KtoraStrona.Content.ToString()) + 1).ToString();
            WczytajStatystyki();
        }

        private void WczytajStatystyki()
        {
            var konwerter = KonwerterStatystykiWybor.SelectedItem == null ? "" : KonwerterStatystykiWybor.SelectedItem.ToString();
            var statystyki = WczytajZBazy(20, (obecnaStrona - 1) * 20, DataOdWybor.SelectedDate, DataDoWybor.SelectedDate, konwerter);
            Statystyki.ItemsSource = statystyki;
        }

        private List<Przeliczenia> WczytajZBazy(int ileWczytaj, int ilePomin, DateTime? dataOd, DateTime? dataDo, string konwerter)
        {
            var przeliczenia = new List<Przeliczenia> { };
            try
            {
                using (var baza = new PrzelicznikPrzeliczenia())
                {
                    var zapytanie = baza.Przeliczenias.AsQueryable();
                    if (dataOd != null)
                    {
                        zapytanie = zapytanie.Where(p => p.data >= dataOd);
                    }
                    if (dataDo != null)
                    {
                        zapytanie = zapytanie.Where(p => p.data <= dataDo);
                    }
                    if (konwerter != "")
                    {
                        zapytanie = zapytanie.Where(p => p.konwerter == konwerter);
                    }

                    var wynik = zapytanie.OrderBy(p => p.id).Skip(ilePomin).ToList();
                    if (wynik.Count < ileWczytaj)
                    {
                        przeliczenia = wynik;
                    }
                    else
                    {
                        przeliczenia = wynik.GetRange(0, ileWczytaj);
                    }
                }
            }
            catch (Exception e)
            { PoleWyjsciowe.Text = e.Message; }

            return przeliczenia;
        }
    }
}
