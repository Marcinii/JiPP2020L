using System;
using System.Collections.Generic;
using System.Text;

namespace przelicznik
{


public class TimeConverter: IConverter
{
    public string Name => "Czas";

        public string Choice => "10- sekundy na minuty\n11- minuty na godziny\n12-godziny na dni";


        public List<string> Units => new List<string>()
        {
            "S",
            "Min ",
            "H"
        };
       

        public double Convert(double choice, double liczba, double wynik)
    {

        if (choice == 10)
        {
                wynik = liczba /60;
        }
        if (choice == 11)
        {
                wynik = liczba /60;
        }
        if (choice == 12)
        {
                wynik = liczba /24;
        }
            return wynik ;
    }
}
}