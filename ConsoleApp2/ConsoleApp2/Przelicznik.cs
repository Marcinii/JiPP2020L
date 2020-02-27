using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public class Przelicznik {
       
       public static double liczTemperature(double jednostka, string strona)
        {
            double result;
            if(strona == "1") // C->F
            {
                result = jednostka * 1.8000 + 32.00;
                return result;
            }
            else if (strona == "2") // F->C
            {
                result = (jednostka - 32.00) / 1.8000;
               return result;
            }
            else
            {
                Console.WriteLine("Podaj odpowiednia liczbe!");
                return 0;
            }
        }
        public static double liczDlugosci(double jednostka, string strona)
        {
            double result;
            if (strona == "1") // K->M
            {
                result = jednostka * 0.62137;
                return result;
            }
            else if (strona == "2") // M->K
            {
                result = jednostka / 0.62137;
                return result;
            }
            else
            {
                Console.WriteLine("Podaj odpowiednia liczbe!");
                return 0;
            }
        }
        public static double liczMase(double jednostka, string strona)
        {
            double result;
            if (strona == "1") // K->F
            {
                result = jednostka * 2.2046;
                return result;
            }
            else if (strona == "2") // F->K
            {
                result = jednostka / 2.2046;
                return result;
            }
            else
            {
                Console.WriteLine("Podaj odpowiednia liczbe!");
                return 0;
            }
        }
    }
}
