using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Iconventer> calculator = new List<Iconventer>()
        {
            new temp(),
            new lenght(),
            new speed()
        };
            Console.WriteLine("Wybierz Kalkukator");
            for (int i = 0; i < calculator.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i+1, calculator[i].Name);
            }
            string choice = Console.ReadLine();
            int range = Convert.ToInt32(choice) - 1;

            Console.WriteLine("Z jednostki");
            for (int i = 0; i < calculator[range].Units.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i+1, calculator[range].Units[i]);
            }

            string unitFrom = Console.ReadLine();
            int fromUnit = int.Parse(unitFrom) - 1;

            Console.WriteLine("Na jednostke");
            for (int i = 0; i < calculator[range].Units.Count; i++)
            {
            Console.WriteLine("({0}) {1}", i+1, calculator[range].Units[i]);
            }
            string getUnit = Console.ReadLine();
            int unitTo = int.Parse(getUnit) - 1;

            Console.WriteLine("Podaj wartosc: ");
            string getValue = Console.ReadLine();
            decimal value = decimal.Parse(getValue);

            decimal result = calculator[range].converterCalculator(fromUnit, unitTo, value);

            Console.WriteLine("Wynik konwersji: " + result);
            
            Console.ReadKey();
        }
    }
}
