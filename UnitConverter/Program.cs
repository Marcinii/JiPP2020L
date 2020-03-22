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
            bool shoudlContinue = true;

            while (shoudlContinue)
            {
                Console.WriteLine("CO CHCESZ ZAMIENIC?\n");
                Console.WriteLine("1. Celcjusze na Fahrenhaity?");
                Console.WriteLine("2. Fahrenhaity na Celcjusze?");
                Console.WriteLine("3. Kilometry na mile?");
                Console.WriteLine("4. Mile na kilometry?");
                Console.WriteLine("5. Kilogram na funt?");
                Console.WriteLine("6. Funt na kilogram?");

                string inputChoice = Console.ReadLine();

                Console.WriteLine("Podaj liczbe do konwersji: ");
                string inputValue = Console.ReadLine();

                int choice = int.Parse(inputChoice);
                int value = int.Parse(inputValue);

                switch (choice)
                {
                    case 1:
                        Temperatura konw1 = new Temperatura();
                        Console.WriteLine("wynik konwersji C -> F: {0}", konw1.Konwerter("c","f",value));
                        break;
                    case 2:
                        Console.WriteLine("Wynik konwersji km -> mi: {0}", value * 10);
                        break;
                    case 3:
                        Console.WriteLine("wynik konwersji C -> F: {0}", value * 2);
                        break;
                    case 4:
                        Console.WriteLine("wynik konwersji C -> F: {0}", value * 2);
                        break;
                    case 5:
                        Console.WriteLine("wynik konwersji C -> F: {0}", value * 2);
                        break;
                    case 6:
                        Console.WriteLine("wynik konwersji C -> F: {0}", value * 2);
                        break;
                    case 7:
                        Console.WriteLine("wynik konwersji C -> F: {0}", value * 2);
                        break;
                    default:
                        shoudlContinue = false;
                        break;

                }
            }
        }
    }
}
