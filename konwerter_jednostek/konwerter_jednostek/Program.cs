using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sholdContinue = true;
            while (sholdContinue)

            {

                Console.WriteLine("Wybierz jedna z opcji:");
                Console.WriteLine("(1) Konwersja Fahrenheita na Celcjusza");
                Console.WriteLine("(2) Konwersja Celcjusza na Fahrenheita");
                Console.WriteLine("(3) Konwersja Mil na Kliometry");
                Console.WriteLine("(4) Konwersja Kilometrów na Mile");
                Console.WriteLine("(5) Konwersja Kilogramów na Funty");
                Console.WriteLine("(6) Konwersja Funty na Kilogramy");

                string inputChoice = Console.ReadLine();
                Console.WriteLine("Podaj liczę do konwersji :");
                string inputValue = Console.ReadLine();

                double choice = double.Parse(inputChoice);
                double value = double.Parse(inputValue);

                    switch (choice)
                {
                    case 1:
                        Console.WriteLine("Wynik Konwersji Fahrenheita na Celcjusza : {0}", (value - 32) * 5 / 9);
                        break;
                    case 2:
                        Console.WriteLine("Wynik Konwersji Celcjusza na Fahrenheita : {0}", (value * 9 / 5) + 32);
                        break;
                    case 3:
                        Console.WriteLine("Wynik Konwersji Mil na Kliometry : {0}", value * 1.61);
                        break;
                    case 4:
                        if (value != 0)
                        {
                            Console.WriteLine("Wynik Konwersji Kilometrów na Mile : {0}", value / 1.61);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Wynik Konwersji Kilogramów na Funty : {0}", value * 2.204);
                        break;
                    case 6:
                        Console.WriteLine("Wynik Konwersji Funty na Kilogramy : {0}", value * 0.4535);
                        break;
                    default:
                        sholdContinue = false;
                        break;
                }


            }
        }
    }
}
