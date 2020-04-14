using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    class Konwenter_Jednostek
    {
        static void Main()
        {
            List<IKonwenter> konwentery = new List<IKonwenter>()
        {
            new konwenter_temperatury(),
            new konwenter_dlugosci(),
            new konwenter_masy(),
            new konwenter_cisnienia()
        };

            Console.WriteLine("Konwenter Jednostek ");
            bool play = true;
            while (play)
            {
                Console.WriteLine("Wybierz opcję: ");
                for (int i = 0; i < konwentery.Count; i++)
                {
                    Console.WriteLine("({0}) {1} {2} {3}", i + 1, konwentery[i].Nazwa, " ", konwentery[i].jednostkii);
                   
                }
                
                
                string pobranywybor = Console.ReadLine();
                int wybor = int.Parse(pobranywybor); // TryParse!
               
                Console.WriteLine("Podaj jednostke z: ");
                string jednostkaZ = Console.ReadLine();

                Console.WriteLine("Podaj jednostke do: ");
                string jednostkadoo = Console.ReadLine();

                Console.Write("Podaj liczbę do konwersji: ");

                string pobranaliczba = Console.ReadLine();
                double liczba = double.Parse(pobranaliczba);
                Console.WriteLine("Wynik konwersji: {0}", konwentery[wybor - 1].Konwertuj(jednostkaZ, jednostkadoo, liczba));
                Console.WriteLine();
            }
        }
    }
}
