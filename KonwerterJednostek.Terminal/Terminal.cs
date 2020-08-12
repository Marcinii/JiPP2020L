using System;
using System.Collections.Generic;
using KonwerterJednostek.Biblioteka;

namespace KonwerterJednostek.Terminal
{
    class KonwerterTerminal
    {
        string wartoscWejsciowaTekst, jednostkaWejsciowa, jednostkaWyjsciowa;
        double wartoscWejsciowa, wartoscWyjsciowa;
        IKonwerter konwerter;

        List<IKonwerter> konwertery;

        private void UstawKonwertery()
        {
            konwertery = new List<IKonwerter>
            {
                new KonwerterMasy(),
                new KonwerterDystansu(),
                new KonwerterObjetosci(),
                new KonwerterTemperatury(),
                new KonwerterCzasu(),
            };
        }

        private void WypiszPomoc()
        {
            Console.WriteLine(
                "KonwerterJednostek\n" +
                "\n" +
                "\n" +
                "Masa - g kg oz\n" +
                "Dystans - m ft yd\n" +
                "Objetosc - m3 cm3 l\n" +
                "Temperatura - C K F\n"
            );
        }

        KonwerterTerminal()
        {
            UstawKonwertery();
            WypiszPomoc();
        }

        private void PobierzWartosc()
        {
            for(; ; )
            {
                Console.WriteLine("Podaj wartosc: ");
                wartoscWejsciowaTekst = Console.ReadLine();
                try
                {
                    wartoscWejsciowa = Double.Parse(wartoscWejsciowaTekst);
                    break;

                }
                catch(System.FormatException)
                {
                    Console.WriteLine("Niepoprawna wartość! Spróbuj ponownie.");
                }
            }
        }

        private void PobierzJednostkeWejsciowa()
        {
            for (; ; )
            {
                Console.WriteLine("Podaj jednostke wejsciowa: ");
                jednostkaWejsciowa = Console.ReadLine();
                if (UstawKonwerter(jednostkaWejsciowa))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawna jednostka wejściowa!");
                }
            }
        }

        private void PobierzJednostkeWyjsciowa()
        {
            for (; ; )
            {
                Console.WriteLine("Podaj jednostke wyjsciowa: ");
                jednostkaWyjsciowa = Console.ReadLine();
                if (konwerter.Jednostki.Contains(jednostkaWyjsciowa))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Niepoprawna jednostka wyjściowa!");
                }
            }
        }

        private bool UstawKonwerter(string jednostka)
        {
            foreach(IKonwerter konw in konwertery)
            {
                if (konw.Jednostki.Contains(jednostka))
                {
                    konwerter = konw;
                    return true;
                }
            }
            return false;
        }

        private void PobierzDane()
        {
            PobierzWartosc();
            PobierzJednostkeWejsciowa();
            PobierzJednostkeWyjsciowa();
        }

        private void Konwertuj()
        {
            wartoscWyjsciowa = konwerter.Konwertuj(wartoscWejsciowa, jednostkaWejsciowa, jednostkaWyjsciowa);
            Console.WriteLine(wartoscWejsciowa + " " + jednostkaWejsciowa + " = " + wartoscWyjsciowa + " " + jednostkaWyjsciowa);
        }

        private void main()
        {
            for (; ; )
            {
                PobierzDane();
                Konwertuj();
            }
        }
        public static void Main()
        {
            KonwerterTerminal konwerterTerm = new KonwerterTerminal();
            konwerterTerm.main();
        }
    }
}
