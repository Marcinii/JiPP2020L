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
            Console.WriteLine("Podaj jednostke z której chcesz przeliczyć: (Km / Mil / C / F / Kg / Funt)");            
            tmp1 = Console.ReadLine();
            if (tmp1 == "C")
            {
                Console.WriteLine("Podaj wartoś do przeliczenia:");
                tmp2 = double.Parse(Console.ReadLine());
                if (tmp2 < -273.15)
                {
                    Console.WriteLine("Błąd wartość nie może być mniejsza od zera absolutnego");
                    Console.WriteLine("Podaj poprawną wartość");
                    tmp2 = double.Parse(Console.ReadLine());
                }
            }
            if (tmp1 == "F")
            {
                Console.WriteLine("Podaj wartoś do przeliczenia:");
                tmp2 = double.Parse(Console.ReadLine());
                if (tmp2 < -459.67)
                {
                    Console.WriteLine("Błąd wartość nie może być mniejsza od zera absolutnego");
                    Console.WriteLine("Podaj poprawną wartość");
                    tmp2 = double.Parse(Console.ReadLine());
                }
            }
            if (tmp1 == "Km" || tmp1 == "Mil" || tmp1 == "Kg" || tmp1 == "Funt")
            {
                Console.WriteLine("Podaj wartoś do przeliczenia:");
                tmp2 = double.Parse(Console.ReadLine());
                if (tmp2 <= 0) 
                {
                    Console.WriteLine("Błąd wartość nie może być mniejsza lub równa 0");
                    Console.WriteLine("Podaj poprawną wartość większą od zera");
                    tmp2 = double.Parse(Console.ReadLine());
                }                
            }            
            Konwerter kalk1 = new Konwerter();
            kalk1.daj_dane(tmp2, tmp1);
            kalk1.konwersja();
            kalk1.daj_wynik();
        }
    }
}
