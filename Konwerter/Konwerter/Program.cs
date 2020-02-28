using System;

namespace Konwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Komunikat na start o opcjach
            Console.WriteLine("Co chcesz zrobic? Podaj liczbe w zaleznosci od operacji:");
            Console.WriteLine("1. Zamiana stopni Celsjusza na stopnie Farenheita.");
            Console.WriteLine("2. Zamiana stopni Farenheita na stopnie Celsjusza.");
            Console.WriteLine("3. Zamiana kilometrow na mile.");
            Console.WriteLine("4. Zamiana mil na kilometry.");
            Console.WriteLine("5. Zamiana kilogramow na funty.");
            Console.WriteLine("6. Zamiana funtow na kilogramy.");

            //Wczytaj wartosc od uzytkownika
            string linia = Console.ReadLine();

            if(linia == "1")
            {
                Console.WriteLine("Podaj wartosc w stopniach Celsjusza:");
                string str = Console.ReadLine();
                double stopnieCel = Double.Parse(str);
                // t [ °F ] = 9/5 × t [ °C ] + 32
                double stopnieFar = (9.0 / 5.0) * stopnieCel + 32;
                Console.WriteLine("Wynik w stopniach Farenheita: " + stopnieFar);
            }
            else if(linia == "2")
            {
                Console.WriteLine("Podaj wartosc w stopniach Farenheita:");
                string str = Console.ReadLine();
                double stopnieFar = Double.Parse(str);
                //t [ °C ] = 5/9 × ( t [ °F ] - 32 )
                double stopnieCel = (5.0 / 9.0) * (stopnieFar - 32);
                Console.WriteLine("Wynik w stopniach Celsjusza: " + stopnieCel);
            }
            else if(linia == "3")
            {
                Console.WriteLine("Podaj wartosc w kilometrach:");
                string str = Console.ReadLine();
                double km = Double.Parse(str);
                double mile = km * 0.62137;
                Console.WriteLine("Wynik w milach: " + mile);
            }
            else if(linia == "4")
            {
                Console.WriteLine("Podaj wartosc w milach:");
                string str = Console.ReadLine();
                double mile = Double.Parse(str);
                double km = mile / 0.62137;
                Console.WriteLine("Wynik w kilometrach: " + km);
            }
            else if(linia == "5")
            {
                Console.WriteLine("Podaj wartosc w kilogramach:");
                string str = Console.ReadLine();
                double kg = Double.Parse(str);
                double funty = kg * 2.2046;
                Console.WriteLine("Wynik w funtach: " + funty);
            }
            else if(linia == "6")
            {
                Console.WriteLine("Podaj wartosc w funtach:");
                string str = Console.ReadLine();
                double funty = Double.Parse(str);
                double kg = funty / 2.2046;
                Console.WriteLine("Wynik w kilogramach: " + kg);
            }
            else
            {
                Console.WriteLine("Nie rozpoznano komendy!");
            }

            Console.WriteLine("Koniec programu, nacisnij enter..");
            Console.Read();
        }
    }
}
