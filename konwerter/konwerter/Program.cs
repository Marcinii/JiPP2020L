using System;

namespace konwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            double tmp2 = 0; string tmp1;
            Console.WriteLine("======================= KOWERTER JEDNOSTEK =======================");
            Console.WriteLine("+     Program konwertuje nastepne jednostki:                     +");
            Console.WriteLine("+     Kilogramy na Funty / Funty na Kilogramy                    +");
            Console.WriteLine("+     Kilogramy na Funty / Funty na Kilogramy                    +");
            Console.WriteLine("+     Stopnie C na F / F na C                                    +");
            Console.WriteLine("+     Odległości Kilometry na Mile / Mile na Kilometry           +");
            Console.WriteLine("==================================================================");
            Console.WriteLine();                        
            Konwerter kalk1 = new Konwerter();
            kalk1.konwersja();
            kalk1.daj_wynik();
        }
    }
}
