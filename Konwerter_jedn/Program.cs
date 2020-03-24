using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    class Program
    {
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
            while (shouldContinue)
            {
                Console.WriteLine("To konwerter jednostek. Wybierz dzialanie.");

                for (int i = 0; i < konwertery.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, konwertery[i].Nazwa);
                }

                string wybor = Console.ReadLine(); //wybor - wybrany numer
                int dzialanie = int.Parse(wybor); //dzialanie - do wykonania

                Console.WriteLine("Wpisz jednostke do konwersji: ");
                string Zjakiej = Console.ReadLine();

                Console.WriteLine("Wpisz jednostke na jaka chcesz konwertowac: ");
                string DOjakiej = Console.ReadLine();

                Console.WriteLine("Wpisz wartosc do konwersji: ");
                string wartosc = Console.ReadLine();

                double zmienna = (double)Convert.ChangeType(wartosc, typeof(double)); 

                double wynikKoncowy = konwertery[dzialanie - 1].naWybr(Zjakiej, DOjakiej, zmienna);
                Console.WriteLine("To jest {0}", wynikKoncowy);
                
            }
            shouldContinue = false;
        }
    
    }
    
}

