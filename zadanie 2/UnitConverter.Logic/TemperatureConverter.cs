using System;
using System.Collections.Generic;
using System.Text;


namespace przelicznik
{
   public class TemperatureConverter: IConverter
    {

        public string Choice => "\n1- Ze stopni Celsjusza na stopnie Farenheita\n2- Ze stopni Farenheita na stopnie Celsjusza\n3- Ze stopni Celsjusza na stopnie Kelwina";






        public string Name => "Temperatury";

        public List<string> Units => new List<string>()
        {
            "C",
            "F ",
            "K"
        };
      
        public double Convert(double choice, double liczba,double wynik)
        {
         
          if (choice == 1)           
                wynik=  9 / 5 * liczba + 32;            
          if (choice == 2)           
                wynik = (liczba - 32) * 5 / 9;            
          if (choice == 3)       
                wynik = (liczba + 273.15);        


            return wynik;
        } 
    }
}
