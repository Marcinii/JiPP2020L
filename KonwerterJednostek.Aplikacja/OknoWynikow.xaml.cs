using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using KonwerterJednostek.Biblioteka;

namespace KonwerterJednostek.Aplikacja
{
    public partial class OknoWynikow : Window
    {
        List<IKonwerter> Konwertery;
        private Komenda KNastepnaStrona, KPoprzedniaStrona, KWczytajDane;
        public const int LiczbaNaStronie = 20;
        private int Strona = 1;


        private void UstawKonwertery()
        {
            Konwertery = new List<IKonwerter>
            {
                new KonwerterMasy(),
                new KonwerterDystansu(),
                new KonwerterObjetosci(),
                new KonwerterTemperatury(),
                new KonwerterCzasu(),
            };
            KonwerterWybor.ItemsSource = Konwertery;
        }

        public OknoWynikow()
        {
            Zainicjalizuj();
        }

        private void Zainicjalizuj()
        {
            InitializeComponent();
            UstawKonwertery();
            PrzygotujKomendy();
        }

        private void PrzygotujKomendy()
        {
            KNastepnaStrona = new Komenda(obj => NastepnaStronaK());
            KPoprzedniaStrona = new Komenda(obj => PoprzedniaStronaK());
            KWczytajDane = new Komenda(obj => WczytajDaneK());
            NastepnaStronaPrzycisk.Command = KNastepnaStrona;
            PoprzednniaStronaPrzycisk.Command = KPoprzedniaStrona;
            WczytajDanePrzycisk.Command = KWczytajDane;
        }

        private void ZminiejszStrone()
        {
            StronaPole.Content = (--Strona).ToString();
        }

        private void ZwiekszStrone()
        {
            StronaPole.Content = (++Strona).ToString();
        }

        private void NastepnaStronaK()
        {
            var dane = BAZA_WybierzDaneStrona(Strona + 1);
            if (dane.Count > 0)
            {
                Wyniki.ItemsSource = dane;
                ZwiekszStrone();
            }
        }

        private void PoprzedniaStronaK()
        {
            var dane = BAZA_WybierzDaneStrona(Strona - 1);
            if (Strona > 1)
            {
                Wyniki.ItemsSource = dane;
                ZminiejszStrone();
            }
        }

        private void RozpocznijAnimacjeWczytywania()
        {
            var animacja = (Storyboard)FindResource("AnimacjaWczytywania");
            animacja.Begin();
        }

        private void WczytajDane()
        {
            var strona = int.Parse(StronaPole.Content.ToString());
            var konwerter = ((IKonwerter)KonwerterWybor.SelectedItem).Nazwa;
            var dataPoczatek = DataPoczatekWybor.SelectedDate;
            var dataKoniec = DataKoniecWybor.SelectedDate;
            Thread t = new Thread(() =>
            {
                BAZA_WczytajZWatkiem(strona, konwerter, dataPoczatek, dataKoniec);
            });
            t.Start();
        }

        private void WczytajDaneK()
        {
            RozpocznijAnimacjeWczytywania();
            WczytajDane();
        }

        /* BAZA DANYCH */

        private List<Wyniki> BAZA_WybierzWynikiZFiltrami(int strona, string konwerter, DateTime? dataPoczatek, DateTime? dataKoniec)
        {
            try
            {
                using (var baza = new BazaKonwersji())
                {
                    var zapytanie = baza.Wynikis.Where(c => c.konwerter == konwerter);
                    if (dataPoczatek != null)
                    {
                        zapytanie = zapytanie.Where(c => c.data >= dataPoczatek.Value);
                    }
                    if (dataKoniec != null)
                    {
                        zapytanie = zapytanie.Where(c => c.data >= dataPoczatek.Value);
                    }
                    return zapytanie.OrderBy(c => c.id).Skip((strona - 1) * LiczbaNaStronie).ToList();
                }
            }
            catch (InvalidOperationException ex)
            { }


            return new List<Wyniki> { };
        }
        private List<Wyniki> BAZA_WybierzDaneStrona(int strona)
        {
            var konwerter = ((IKonwerter)KonwerterWybor.SelectedItem).Nazwa;
            var dataPoczatek = DataPoczatekWybor.SelectedDate;
            var dataKoniec = DataKoniecWybor.SelectedDate;

            return BAZA_WybierzWynikiZFiltrami(strona, konwerter, dataPoczatek, dataKoniec);
        }
        private void BAZA_WczytajZWatkiem(int strona, string konwerter, DateTime? dataPoczatek, DateTime? dataKoniec)
        {
            var output = BAZA_WybierzWynikiZFiltrami(strona, konwerter, dataPoczatek, dataKoniec);
            Thread.Sleep(1500);
            Dispatcher.Invoke(() =>
            {
                Wyniki.ItemsSource = output;
            });
        }
    }
}
