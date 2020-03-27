using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_console
{
    class Waga
    {
        public static void WagaKonwerter()
        {
            Console.Title = "Konwerter Wag";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Kilogramy na Funty");
                Console.WriteLine("2 - Funty na Kilogramy");
                Console.WriteLine("3 - Powrot");
                Console.WriteLine("4 - EXIT");

                ConsoleKeyInfo wybor = Console.ReadKey();
                switch (wybor.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        KilogramyNaFunty();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        FuntyNaKilogramy();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Menu.StartMenu();
                        break;

                    case ConsoleKey.Escape:
                    case ConsoleKey.D4:
                        Environment.Exit(0); break;

                    default: break;
                }
            }
        }
        static void KilogramyNaFunty()
        {
            Console.WriteLine("Wpisz wage w kilogramach");
            double kg = double.Parse(Console.ReadLine());
            double kgtofunt = kg * 2.2046;
            Console.WriteLine(kg + " kilogramow to " + kgtofunt +" funtow");
            Console.ReadKey();
        }

        static void FuntyNaKilogramy()
        {
            Console.WriteLine("Wpisz wage w Funtach");
            double funt = double.Parse(Console.ReadLine());
            double funttokg = funt / 2.2046;
            Console.WriteLine(funt + " funtow to " + funttokg +" kilogramow");
            Console.ReadKey();
        }
    }
}
