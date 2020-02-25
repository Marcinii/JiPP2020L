using System;

namespace konwerter
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("PZELICZNIK MIAR: ");
            Console.WriteLine("Kg na funty i odwrotnie");
            Console.WriteLine("C na F i odwrotnie");
            Console.WriteLine("Km na Mile i odwrotnie");
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine();
            //TWORZENI OBJEKTU I TYM SAMYM URUCHAMIANIE KONSTRUKTORA
            Konwerter konwerter = new Konwerter();
            //Wywolanei funkcji konwersja
            konwerter.konwersja();
            //Wypisanie wyniku
            konwerter.wynik();

        }
    }
}