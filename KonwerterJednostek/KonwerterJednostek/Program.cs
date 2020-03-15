using System;
using System.Collections.Generic;
using System.Threading;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
            {
                new Temp(),
                new Length(),
                new Weight(),
                new Energy()
            };

            Console.WriteLine("WITAJ W KONWERTERZE JEDNOSTEK!");
            Console.WriteLine();

            string choiceString;
            while (true)
            {

                Console.WriteLine("===================================================");
                Console.WriteLine("Jaka wielkosc chcesz konwertowac??");
                for(int i=0; i<converters.Count; i++)
                {
                    Console.WriteLine("\t({0}) {1}", i + 1, converters[i].Name);
                }
                Console.WriteLine("\t(q) QUIT");
                Console.WriteLine();
                choiceString = Console.ReadLine();
                bool success = int.TryParse(choiceString, out int choice);
                if (!success) { choice = 0; Environment.Exit(0); }
                if(choice<0 || choice > 4) { Environment.Exit(0); }
                Console.WriteLine();

                converters[choice - 1].UnitConv();

                Thread.Sleep(1500);
                Console.WriteLine("\n\n\n\n\n");
            }
        }
    }
}