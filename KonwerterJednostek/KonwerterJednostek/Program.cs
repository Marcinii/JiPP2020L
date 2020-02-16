using System;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w konwerterze jednostek!");
            Console.WriteLine();
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("\t(1) Konwersja temperatury");
            Console.WriteLine("\t(2) Konwersja dlugosci");
            Console.WriteLine("\t(3) Konwersja masy");
            Console.WriteLine();
            
            int ch1, ch2;
            ch1 = Convert.ToInt32(Console.ReadLine());

            switch (ch1)
            {
                case 1:
                    Console.WriteLine("KONWERSJA TEMPERATURY");
                    Console.WriteLine("\t(1) Celsjusz\t->\tFahrenheit");
                    Console.WriteLine("\t(2) Fahrenheit\t->\tCelsjusz");
                    Console.WriteLine();
                    //KOD
                    break;
                case 2:
                    Console.WriteLine("KONWERSJA DLUGOSCI");
                    Console.WriteLine("\t(1) Kilometry\t->\tMile");
                    Console.WriteLine("\t(2) Mile\t->\tKilometry");
                    Console.WriteLine();
                    //KOD
                    break;
                case 3:
                    Console.WriteLine("KONWERSJA MASY");
                    Console.WriteLine("\t(1) Kilogramy\t->\tFunty");
                    Console.WriteLine("\t(2) Funty\t->\tKilogramy");
                    Console.WriteLine();
                    //KOD
                    break;
                default:
                    Console.WriteLine("!!! ERROR !!!");
                    break;
            }
        }
    }
}
