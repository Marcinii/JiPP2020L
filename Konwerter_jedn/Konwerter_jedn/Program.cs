using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    class Program
    {
        static void podajDane(IKonwerter_jedn konwerter)
        {
            Console.WriteLine("Podaj jednostke do konwersji: ");
            string Zjakiej = Console.ReadLine();
            Console.WriteLine("Podaj jednostke na jaka chcesz konwertowac: ");
            string DOjakiej = Console.ReadLine();
            Console.WriteLine("Podaj wartosc do konwersji: ");
            string dane = Console.ReadLine();
            string wynikKoncowy = konwerter.naWybr(Zjakiej, DOjakiej, dane);
            Console.WriteLine("To jest {0}", wynikKoncowy);
        }
        static void Main(string[] args)
        {
            List<IKonwerter_jedn> konwertery = new List<IKonwerter_jedn>()
            {
                new temperatury(),
                new cisnienia(),
                new masy(),
                new odleglosci(),
            };
            bool shouldContinue = true;
            IKonwerter_jedn wybranyKonwerter;
            while (shouldContinue)
            {
                Console.WriteLine("To konwerter jednostek. Wybierz dzialanie.");

                for (int i = 0; i < konwertery.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, konwertery[i].Nazwa);
                }

                string wybor = Console.ReadLine(); //wybor - wybrany numer
                switch (wybor)
                {
                    case "1":
                        wybranyKonwerter = konwertery[0];
                        podajDane(wybranyKonwerter);
                        break;
                    case "2":
                        wybranyKonwerter = konwertery[1];
                        podajDane(wybranyKonwerter);
                        break;
                    case "3":
                        wybranyKonwerter = konwertery[2];
                        podajDane(wybranyKonwerter);
                        break;
                    case "4":
                        wybranyKonwerter = konwertery[3];
                        podajDane(wybranyKonwerter);
                        break;
                }
                /* Console.WriteLine("Wpisz jednostke do konwersji: ");
                 string Zjakiej = Console.ReadLine();

                 Console.WriteLine("Wpisz jednostke na jaka chcesz konwertowac: ");
                 string DOjakiej = Console.ReadLine();

                 Console.WriteLine("Wpisz wartosc do konwersji: ");
                 string wartosc = Console.ReadLine();

                 double zmienna = (double)Convert.ChangeType(wartosc, typeof(double)); //kurde nie wiem, chyba zmienia ze stringa na double
                 //double zmienna = decimal.Parse(wartosc); //to bylo wczesniej

                 double wynikKoncowy = konwertery[dzialanie - 1].naWybr(Zjakiej, DOjakiej, zmienna);
                 Console.WriteLine("To jest {0}", wynikKoncowy);

             }*/
                shouldContinue = false;
            }

        }

    }
}

