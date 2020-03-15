using System;
using System.Collections.Generic;
using System.Text;

namespace przelicznik
{
    public class WeightConverter:IConverter
    {

        public string Choice => "\n4- kilogramy na funty\n5- funty na kilogramy\n6- kilogramy na tony";
             
            
      
       
        public List<string> Units => new List<string>()
        {
            "kg",
            "funty",
            "tony"
        };

        public string Name => "wagi";

        public double Convert(double choice, double liczba, double wynik)
        {

            if (choice == 5)
            {
                wynik = liczba * 2.2046;
            }
            if (choice == 4)
            {
                wynik = liczba * 0.4535;
            }
            if (choice == 6)
            {
                wynik = liczba * 1000;
            }
            return wynik ;
        }
    }
}
