using System;
using System.Threading;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WITAJ W KONWERTERZE JEDNOSTEK!");
            Console.WriteLine();
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("\t(1) Konwersja temperatury");
            Console.WriteLine("\t(2) Konwersja dlugosci");
            Console.WriteLine("\t(3) Konwersja masy");
            Console.WriteLine("\t(q) QUIT");
            Console.WriteLine();

            string ch;
            while (true)
            {
                ch = Console.ReadLine();
                Console.WriteLine();

                switch (ch)
                {
                    case "1":
                        Temp t = new Temp();
                        t.TempConv();
                        break;
                    case "2":
                        Length l = new Length();
                        l.LengthConv();
                        break;
                    case "3":
                        Weight w = new Weight();
                        w.WeightConv();
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("!!! ERROR !!!");
                        break;
                }

                Thread.Sleep(1500);
                //Console.WriteLine("WITAJ W KONWERTERZE JEDNOSTEK!");
                Console.WriteLine("\n\n\n\n\n===================================================");
                //Console.WriteLine();
                Console.WriteLine("Co chcesz zrobic?");
                Console.WriteLine("\t(1) Konwersja temperatury");
                Console.WriteLine("\t(2) Konwersja dlugosci");
                Console.WriteLine("\t(3) Konwersja masy");
                Console.WriteLine("\t(q) QUIT");
                Console.WriteLine();
            }
        }
    }
}
