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
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            //dowolna zmiaana
        }
    }
}
