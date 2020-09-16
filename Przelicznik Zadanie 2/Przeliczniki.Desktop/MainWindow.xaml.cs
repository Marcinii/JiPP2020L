using Przelicznik.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Przelicznik.Controls;
using Przelicznik.Desktop;

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

            przelicznikStatystykiWybor.ItemsSource = Nazwy;
            Kocena.UstawKolor(OstatniaOcena());
            DodajKomendy();
        }

        private void DodajKomendy()
        {
            ObliczPrzycisk.Command = new Komenda(x => ObliczPrzyciskKomenda());
            StronaMinus.Command = new Komenda(x => StronaMinusKomenda());
            StronaPlus.Command = new Komenda(x => StronaPlusKomenda());
            WybierzPrzycisk.Command = new Komenda(x => WybierzPrzyciskKomenda());
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

        private void ObliczPrzyciskKomenda()
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

        private void ZapiszWynikDoBazy(double wartosc, double wynik, string przelicznik, string jednostkaZ, string jednostkaDo)
        {
            try
            {
                using (var baza = new PrzelicznikPrzeliczenia())
                {
                    baza.Przeliczenias.Add(new Przeliczenia
                    {
                        konwerter = przelicznik,
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

        private void WybierzPrzyciskKomenda()
        {
            WczytajStatystyki();
        }

        private void StronaMinusKomenda()
        {
            if (obecnaStrona != 1)
            {
                obecnaStrona = obecnaStrona - 1;
                KtoraStrona.Content = (int.Parse(KtoraStrona.Content.ToString()) - 1).ToString();
            }
            WczytajStatystyki();
        }

        private void StronaPlusKomenda()
        {
            obecnaStrona = obecnaStrona + 1;
            KtoraStrona.Content = (int.Parse(KtoraStrona.Content.ToString()) + 1).ToString();
            WczytajStatystyki();
        }

        

        private void WczytajStatystyki()
        {
            var przelicznik = przelicznikStatystykiWybor.SelectedItem == null ? "" : przelicznikStatystykiWybor.SelectedItem.ToString();
            var statystyki = WczytajZBazy(20, (obecnaStrona - 1) * 20, DataOdWybor.SelectedDate, DataDoWybor.SelectedDate, przelicznik);
            Statystyki.ItemsSource = statystyki;
        }

        private List<Przeliczenia> WczytajZBazy(int ileWczytaj, int ilePomin, DateTime? dataOd, DateTime? dataDo, string przelicznik)
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
                    if (przelicznik != "")
                    {
                        zapytanie = zapytanie.Where(p => p.konwerter == przelicznik);
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
        private void ZapiszOcene(int ocena)
        {
            try
            {
                using (var baza = new PrzeliczeniaOceny())
                {
                    baza.Ocenies.Add(new Oceny
                    {
                        ocena = ocena
                    });
                    baza.SaveChanges();
                }
            }
            catch (Exception e)
            {
                PoleWyjsciowe.Text = e.Message;
            }
        }

        private int OstatniaOcena()
        {
            try
            {
                using (var baza = new PrzeliczeniaOceny())
                {
                    var ocena = baza.Ocenies.Where(o => o.id == baza.Ocenies.OrderByDescending(x => x.id).FirstOrDefault().id).FirstOrDefault();
                    if (ocena == null)
                    {
                        return 0;
                    }
                    return ocena.ocena;
                }
            }
            catch (InvalidOperationException ex)
            { return 0; }
        }

        private void OcenaZmiana(object sender, OcenaKontrolka.PrzesylaneArgumenty e)
        {
            var ocena = e.WysylanaOcena;
            Kocena.UstawKolor(ocena);
            ZapiszOcene(ocena);
        }

    }
}
