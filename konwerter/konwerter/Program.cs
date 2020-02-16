using System;

namespace konwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ KOWERTER JEDNOSTEK ============");
            Console.WriteLine("Program konwertuje nastepne jednostki:");
            Console.WriteLine("Kilogramy na Funty / Funty na Kilogramy");
            Console.WriteLine("Kilogramy na Funty / Funty na Kilogramy");
            Console.WriteLine("Stopnie C na F / F na C");
            Console.WriteLine("Odległości Kilometry na Mile / Mile na Kilometry");
            Console.WriteLine("Podaj wartoś do przeliczenia:");
            double tmp1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Jednostke: (Km / Mil / C / F / Kg / Funt");
            string tmp2 = Console.ReadLine();
            Konwerter kalk1 = new Konwerter();
            kalk1.daj_dane(tmp1, tmp2);
            kalk1.konwersja();
            kalk1.daj_wynik();
        }
    }
}
