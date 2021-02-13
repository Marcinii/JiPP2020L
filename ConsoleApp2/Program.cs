using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IKonwerter> konwertery = new List<IKonwerter>()
            {
                new Temperatura(),
                new Odleglosc(),
                new Masa(),
                new Energia()
            };

            bool shoudlContinue = true;

            while (shoudlContinue)
            {
                Console.WriteLine("Wybierz opcje: ");

                for(int i=0; i <konwertery.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, konwertery[i].Name);
                }

                string wprowadzonyWybor = Console.ReadLine();
                int wybor = int.Parse(wprowadzonyWybor);

                Console.WriteLine("Podaj jednostke z: ");
                string Z = Console.ReadLine();

                Console.WriteLine("Podaj jednostke do: ");
                string Do = Console.ReadLine();

                Console.WriteLine("Podaj liczbe do konwersji: ");
                string wprowadzonaWartosc = Console.ReadLine();

                int wartosc = int.Parse(wprowadzonaWartosc);

                double Wynik= konwertery[wybor - 1].Konwert(Z, Do, wartosc);

                Console.WriteLine("Wynik konwersji: {0}", Wynik);

                Console.ReadKey();

                shoudlContinue = false;
            }
        }
    }
}

