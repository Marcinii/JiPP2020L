using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnitConverter_M2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Konwerter: wybierz opcje konwersji:");
            List<IConv> listOfConverters = new List<IConv>()
            {
                new TemperatureConv(),
                new MassConv(),
                new LengthConv(),
                new PowerConv()
            };


            while (true)
            {
                string unitFrom, unitTo;
                int typeOfConversion;
                decimal valueToConvert, retVal;

                // wyswietl wszystkie opcje
                for (int i = 0; i< listOfConverters.Count; i++) Console.WriteLine("({0}): {1}", i, listOfConverters[i]);

                // typ konwersji
                typeOfConversion = int.Parse(Console.ReadLine());

                // jednostka z
                Console.WriteLine("Podaj jednostke, z ktorej chcesz konwertowac: ");
                unitFrom = Console.ReadLine();

                // jednostka do
                Console.WriteLine("Podaj jednostke, do ktorej chcesz konwertowac: ");
                unitTo = Console.ReadLine();

                // wartosc do konwersji
                Console.WriteLine("Podaj liczbe do konwersji: ");
                // tutaj te sztuczki z NumberStyles.Any, CultureInfo.InvariantCulture, bo parser nie rozumial zapisu z kropka "1.1"
                valueToConvert = Decimal.Parse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture);

                // zwrocenie wyniku
                retVal = listOfConverters[typeOfConversion].convert(unitFrom, unitTo, valueToConvert);
                Console.WriteLine("Wynik konwersji: {0}{1}", retVal, unitTo);


                // kwestia zakonczenia programu
                Console.WriteLine("Czy zakonczyc? (t/n): ");
                string resp = Console.ReadLine();
                // jesli tak, to zakoncz program
                if (resp.Equals("t")) return;
            }

        }
    }
}
