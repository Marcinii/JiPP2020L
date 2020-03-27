using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_console
{
    class Odleglosc
    {
        public static void OdlegloscKonwerter()
        {
            Console.Title = "Konwerter Odleglosci";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Kilometry na Mile");
                Console.WriteLine("2 - Mile na Kilometry");
                Console.WriteLine("3 - Powrot");
                Console.WriteLine("4 - EXIT");

                ConsoleKeyInfo wybor = Console.ReadKey();
                switch (wybor.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        KilometryNaMile();
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        MileNaKilometry();
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
        static void KilometryNaMile()
        {
            Console.WriteLine("Wpisz odleglosc w kilometrach");
            double km = double.Parse(Console.ReadLine());
            double kmtomil = km * 0.62137;
            Console.WriteLine(km + " kilometrow to " + kmtomil +" mil");
            Console.ReadKey();
        }

        static void MileNaKilometry()
        {
            Console.WriteLine("Wpisz odleglosc w milach");
            double mila = double.Parse(Console.ReadLine());
            double miltokm = mila / 0.62;
            Console.WriteLine(mila + " mil to " + miltokm +" kilometrow");
            Console.ReadKey();
        }
    }
}
