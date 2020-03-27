using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_console
{
    static class Menu
    {
        public static void StartMenu()
        {
            Console.Title = "Menu";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("!!!Konwerter!!!");
                Console.WriteLine("1 - Temperatura");
                Console.WriteLine("2 - Odleglosc");
                Console.WriteLine("3 - Waga");
                Console.WriteLine("4 - EXIT");

                ConsoleKeyInfo wybor = Console.ReadKey();
                switch (wybor.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Temperatura.TemperaturaKonwerter();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        Odleglosc.OdlegloscKonwerter();
                        break;

                    case ConsoleKey.D3:
                        Console.Clear();
                        Waga.WagaKonwerter();
                        break;

                    case ConsoleKey.Escape:
                    case ConsoleKey.D4:
                        Environment.Exit(0); break;

                    default: break;
                }
            }
        }
    }
}
