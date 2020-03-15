using System;
using System.Collections.Generic;
using System.Text;

namespace przelicznik
{
    public class LenghtConverter:IConverter
    {
        public string Name => "Długości";

        public string Choice => "\n7- Z kilometrów na mile\n8- Z mili na kilometry\n9- Z kilometrów na metry";


      
       
        public List<string> Units => new List<string>()
        {
            "mile",
            "kilometry",
            "metry"



        };

        public double Convert(double choice, double liczba,double wynik)
        {

            if (choice == 8)
            {
                wynik = liczba * 1.609344;
            }
            if (choice == 7)
            {
                wynik = liczba / 1.609344;
            }
            if (choice == 9)
            {
                wynik = liczba / 1000;
            }
            return wynik;
        }
    }
}
