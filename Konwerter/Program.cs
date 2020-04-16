using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IKonwerter> konwertery = new List<IKonwerter>()
            {
                new KonwerterTemperatura(),
                new KonwerterOdleglosc(),
                new KonwerterWaga(),
                new KonwerterPredkosc(),
            };

            Console.WriteLine("Witamy w Konwerterze Jednostek");

            Console.WriteLine("Wybierz opcję: ");

            for (int i = 0; i < konwertery.Count; i++)
            {
                Console.WriteLine("({0}) {1} {2} {3}", i + 1, konwertery[i].Name," ", konwertery[i].jednostki);
            }

            string twojwybor= Console.ReadLine();
            int wybor = int.Parse(twojwybor); 

            Console.WriteLine("Podaj jednostek z: ");
            string jwejsciowa= Console.ReadLine();

            Console.WriteLine("Podaj jednostkę do: ");
            string jdocelowa= Console.ReadLine();

            Console.WriteLine("Podaj liczbę do konwersji: ");
            string liczba = Console.ReadLine();
            int liczbaw = int.Parse(liczba);

            double wynikk = konwertery[wybor - 1].Konwertuj(jwejsciowa, jdocelowa, liczbaw);

            Console.WriteLine("Wynik konwersji: {0}", wynikk);
            Console.ReadKey();
        }
    }
}
