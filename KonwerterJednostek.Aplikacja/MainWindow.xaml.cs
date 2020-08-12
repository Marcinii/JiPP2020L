using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using KonwerterJednostek.Biblioteka;

namespace KonwerterJednostek.Aplikacja
{
    public partial class GlowneOkno : Window
    {
        List<IKonwerter> Konwertery;
        private Komenda KKonwertuj, KOknoWynikow;

        public GlowneOkno()
        {
            Zainicjalizuj();
        }

        private void Zainicjalizuj()
        {
            InitializeComponent();
            WczytajOceneIZakoloruj();
            UstawKonwertery();
            PrzygotujKomendy();
        }

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

        private void PrzygotujKomendy()
        {
            KKonwertuj = new Komenda(obj => Konwertuj());
            KOknoWynikow = new Komenda(obj => OknoWynikowK());
            PrzyciskKonwertuj.Command = KKonwertuj;
            PrzyciskStatystyki.Command = KOknoWynikow;
        }

        private void KonwerterWybrany(object sender, SelectionChangedEventArgs e)
        {
            WyczyscPole();
            UstawJednostki();
        }

        private IKonwerter ObecnyKonwerter()
        {
            return (IKonwerter)KonwerterWybor.SelectedItem;
        }

        private void UstawJednostki()
        {
            IKonwerter konwerter = ObecnyKonwerter();
            JednostkaWejsciowaWybor.ItemsSource = konwerter.Jednostki;
            JednostkaWyjsciowaWybor.ItemsSource = konwerter.Jednostki;
        }

        private void WypiszTekst(string tekst)
        {
            PoleTekstoweWyjsciowe.Text = tekst;
            PoleTekstoweWyjsciowe.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void WypiszBlad(string tekst)
        {
            PoleTekstoweWyjsciowe.Text = tekst;
            PoleTekstoweWyjsciowe.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }

        private void WyczyscPole()
        {
            PoleWartosciWejsciowej.Clear();
        }

        private bool KonwerterWybrany()
        {
            return KonwerterWybor.SelectedIndex >= 0;
        }

        private bool JednostkiWybrane()
        {
            return JednostkaWejsciowaWybor.SelectedIndex >= 0 && JednostkaWyjsciowaWybor.SelectedIndex >= 0;
        }

        private bool SprawdzWybor()
        {
            if (!KonwerterWybrany()) { WypiszBlad("Wybierz Konwerter"); }
            else if (!JednostkiWybrane()) { WypiszBlad("Wybierz jednostki"); }
            else { return true; }

            return false;
        }

        private void Oblicz()
        {
            IKonwerter konwerter = ObecnyKonwerter();
            string jednWejsc = JednostkaWejsciowaWybor.SelectedItem.ToString();
            string jednWyjsc = JednostkaWyjsciowaWybor.SelectedItem.ToString();
            try
            {
                double wartWejsc = Double.Parse(PoleWartosciWejsciowej.Text);
                double wartWyjsc = konwerter.Konwertuj(wartWejsc, jednWejsc, jednWyjsc);
                BAZA_ZapiszWynik(DateTime.Now, konwerter.Nazwa, wartWejsc, wartWyjsc, jednWejsc, jednWyjsc);
                WypiszTekst(wartWyjsc.ToString() + " " + jednWyjsc);
            }
            catch (System.FormatException)
            {
                WypiszBlad("Niepoprawna wartość" + PoleWartosciWejsciowej.Text);
            }
        }

        private void Konwertuj()
        {
            if (SprawdzWybor()) { Oblicz(); }
        }

        private void OcenaZmieniona(object sender, Kontrolki.KontrolkaOceny.PrzesylaneArgumenty e)
        {
            var ocena = e.OcenaUzytkownika;
            KontrolkaOceny.Zakoloruj(ocena);
            BAZA_ZapiszOcene(ocena);
        }

        private void WczytajOceneIZakoloruj()
        {
            var ocena = BAZA_WczytajOstatniaOcene();
            KontrolkaOceny.Zakoloruj(ocena);
        }

        private void OknoWynikowK()
        {
            OknoWynikow okno = new OknoWynikow();
            okno.Show();
        }

        /* BAZA DANYCH */
        private void BAZA_ZapiszWynik(
            DateTime dataObliczenia,
            string konwerter,
            double wartWejsc,
            double wartWyjsc,
            string jednWejsc,
            string jednWyjsc
            )
        {
            try
            {
                using (var baza = new BazaKonwersji())
                {
                    baza.Wynikis.Add(new Wyniki
                    {
                        data = dataObliczenia,
                        konwerter = konwerter,
                        wartoscWejsciowa = wartWejsc,
                        wartoscWyjsciowa = wartWyjsc,
                        jednostkaWejsciowa = jednWejsc,
                        jednostkaWyjsciowa = jednWyjsc,
                    });
                    baza.SaveChanges();
                }
            }
            catch (InvalidOperationException ex)
            { Console.WriteLine(ex.Message); }

        }
        private void BAZA_ZapiszOcene(int ocenaUzytkownika)
        {
            try
            {
                using (var baza = new BazaOcen())
                {
                    baza.Ocenys.Add(new Oceny { ocena = ocenaUzytkownika });
                    baza.SaveChanges();
                }
            }
            catch (InvalidOperationException ex)
            { }
        }
        private int BAZA_IdOstatniaOcena()
        {
            try
            {
                using (var baza = new BazaOcen())
                {
                    var id = baza.Ocenys.OrderByDescending(o => o.id).FirstOrDefault();
                    if (id == null)
                    {
                        return 0;
                    }
                    return id.id;
                }
            }
            catch (InvalidOperationException ex)
            { return 0; }
        }
        private int BAZA_WczytajOstatniaOcene()
        {
            try
            {
                using (var baza = new BazaOcen())
                {
                    var id = BAZA_IdOstatniaOcena();
                    var ocena = baza.Ocenys.Where(r => r.id == id).FirstOrDefault();
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

    }
}
