using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Logic;

namespace Konwerter
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IKonwerter> Konwertery = new List<IKonwerter>
            {
                new KonwerterCzasu(),
                new KonwerterDlugosci(),
                new KonwerterWagi(),
                new KonwerterTemperatury()
            };

            bool kontynuacja = true;

            while (kontynuacja) { 

            for (int i = 0; i < Konwertery.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + Konwertery[i].Nazwa);
            }



            Console.Write("Wybor Konwertera: ");
            int wybor = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj wartosc: ");
            //double value = Double.Parse(Console.ReadLine());
            string wartosc = Console.ReadLine();
            Console.WriteLine("Z jakiej jednostki chcesz zamienic?");
            string jednostkaZ = Console.ReadLine();
            Console.WriteLine("Na jaka jednostke chcesz zamienic?");
            string jednostkaDo = Console.ReadLine();

            Console.WriteLine("Wynik = " + Konwertery[wybor - 1]?.Konwertuj(jednostkaZ, jednostkaDo, wartosc));

            kontynuacja = false;

            }


        }
    }
}