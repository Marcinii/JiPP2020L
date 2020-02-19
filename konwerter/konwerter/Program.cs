using System;

namespace konwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================= KOWERTER JEDNOSTEK =======================");
            Console.WriteLine("+     Program konwertuje nastepne jednostki:                     +");
            Console.WriteLine("+     Kilogramy na Funty / Funty na Kilogramy                    +");
            Console.WriteLine("+     Kilogramy na Funty / Funty na Kilogramy                    +");
            Console.WriteLine("+     Stopnie C na F / F na C                                    +");
            Console.WriteLine("+     Odległości Kilometry na Mile / Mile na Kilometry           +");
            Console.WriteLine("==================================================================");
            Console.WriteLine();                        
            Konwerter konwerter = new Konwerter();
            konwerter.konwersja();
            konwerter.daj_wynik();

            konwerter.daj_dane_i_konwertuj(125, "Kg");       
            konwerter.daj_wynik();

            Konwerter konwerter2 = new Konwerter(-25, "F");
            konwerter2.konwersja();
            konwerter2.daj_wynik();
        }
    }
}