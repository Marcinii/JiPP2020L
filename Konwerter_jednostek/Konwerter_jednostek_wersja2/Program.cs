using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek_wersja2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ikonwenter> converters = new List<Ikonwenter>()
            {
                new KonwerterCelcjusza(),
                new KonwerterFahrenheita(),
                new KonwerterKilkometrow(),
                new KonwerterMil(),
                new KonwerterKilogramow(),
                new KonwerterFuntow(),
                new KonwerterCali(),
                new KonwerterCzasu()

                
            };
            bool sholdContinue = true;

            while (sholdContinue)
            {
                Console.WriteLine("Wybierz opcję: ");

                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
                }


                string inputChoice = Console.ReadLine();


                Console.WriteLine("Podaj z Jakiej Jednostki konwertujesz: ");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Podaj do Jakiej Jednostki konwertujesz: ");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Podaj liczbę do konwersji: ");
                string inputValue = Console.ReadLine();

                int choice = int.Parse(inputChoice);
                double value = double.Parse(inputValue);

                string result = converters[choice - 1].Convert(unitFrom, unitTo, value.ToString());

                Console.WriteLine("Wynik konwersji: {0}", result);

            }
        }
    }
}
