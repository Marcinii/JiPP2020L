using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_console
{
    class Temperatura
    {
        public static void TemperaturaKonwerter()
        {
            Console.Title = "Konwerter Temperatur";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Celcjusz na Farenhait");
                Console.WriteLine("2 - Farenhait na Celcjusz");
                Console.WriteLine("3 - Powrot");
                Console.WriteLine("4 - EXIT");

                ConsoleKeyInfo wybor = Console.ReadKey();
                switch (wybor.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        CelcjuszNaFarenhait();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        FarenhaitNaCelcjusz();
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
        static void CelcjuszNaFarenhait()
        {
            Console.WriteLine("Wpisz temperature w Celcjuszach");
            double celcjusz = double.Parse(Console.ReadLine());
            double CtoF = ((celcjusz * 9) / 5) + 32;
            Console.WriteLine(celcjusz +" stopni Celcjusza to " + CtoF +" stopni Farenheita" );
            Console.ReadKey();
        }

        static void FarenhaitNaCelcjusz()
        {
            Console.WriteLine("Wpisz temperature w Farenhaitach");
            double farenhait = double.Parse(Console.ReadLine());
            double FtoC = ((farenhait - 32) / 9) * 5;
            Console.WriteLine(farenhait + " stopni Farehaita to " + FtoC +" stopni Celcjusza");
            Console.ReadKey();
        }
    }
}
