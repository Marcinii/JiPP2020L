using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount;

            Console.WriteLine("Konwerter jednostek");
            Console.WriteLine("a - Stopnie Celsjusza na Fahrenheita");
            Console.WriteLine("b - Stopnie Fahrenheita na Celsjusza");
            Console.WriteLine("c - Kilometry na mile");
            Console.WriteLine("d - Mile na kilometry");
            Console.WriteLine("e - Kilogramy na funty");
            Console.WriteLine("f - Funty na kilogramy");
            Console.WriteLine("Nacisnij odpowiedni klawisz...");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    Console.WriteLine("Wprowadz liczbe stopni Celsjusza:");
                    amount = Double.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " C to " + Math.Round(UnitConvertion.celToFahr(amount)) + " F");
                    break;
                case ConsoleKey.B:
                    Console.WriteLine("Wprowadz liczbe stopni Fahrenheita:");
                    amount = Double.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " F to " + Math.Round(UnitConvertion.fahrToCel(amount)) + " C");
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("Wprowadz liczbe kilometrow:");
                    amount = Double.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " km to " + Math.Round(UnitConvertion.kmToMile(amount)) + " m");
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("Wprowadz liczbe mil:");
                    amount = Double.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " m to " + Math.Round(UnitConvertion.mileToKm(amount)) + " km");
                    break;
                case ConsoleKey.E:
                    Console.WriteLine("Wprowadz liczbe kilogramow:");
                    amount = Double.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " kg to " + Math.Round(UnitConvertion.kgToPound(amount)) + " ibs");
                    break;
                case ConsoleKey.F:
                    Console.WriteLine("Wprowadz liczbe funtow:");
                    amount = Double.Parse(Console.ReadLine());
                    Console.WriteLine(amount + " ibs to " + Math.Round(UnitConvertion.poundToKg(amount)) + " kg");
                    break;
                default:
                    Console.WriteLine("Wprowadzono zla opcje:");
                    break;
            }
            Console.WriteLine("Wcisnij dowolny klawisz, aby zakonczyc...");
            Console.ReadKey();

        }
    }
}
