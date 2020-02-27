using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitChanger
{
    class Program
    {

        static double tempConvert()
        {
            Console.WriteLine("Podaj wartosc dla temp: ");
            string value = Console.ReadLine();

            Console.WriteLine("Podajesz Wartosc w: \n1. Celsjusz \n2. FarenHeit");
            string choice = Console.ReadLine();
            double sum;

            switch (choice)
            {
                case "1":
                 sum = ((9 * Convert.ToDouble(value)) / 5) + 32;
                return sum;


                case "2":
            
                 sum = ((Convert.ToDouble(value) - 32) / 1.8);
                return sum;
            }
             return 0;

        }

        static double lengthCon()
        {
            Console.WriteLine("Podaj wartosc dla dlugosci: ");
            string value = Console.ReadLine();

            Console.WriteLine("Podajesz Wartosc w: \n1. Kilometry \n2. Mile");
            string choice = Console.ReadLine();

            double sum;

            switch (choice)
            {
                
                case "1":
                sum = (Convert.ToDouble(value) * 0.62137);
                return sum;

                case "2": 
                sum = (Convert.ToDouble(value) / 0.62137);
                return sum;
            }
            return 0;

        }

        static double weightConvert()
        {
            Console.WriteLine("Podaj wartosc dla Wagi: ");
            string value = Console.ReadLine();

            Console.WriteLine("Podajesz Wartosc w: \n1. Kilogramy \n2. Funty");
            string choice = Console.ReadLine();
            double sum;
            switch (choice)
            {

                case "1":

                    sum = (Convert.ToDouble(value) * 2.2046);
                    return sum;



                case "2":
                    sum = (Convert.ToDouble(value) / 2.2046);
                    return sum;
            }
            return 0;

        }
           

        static void Main(string[] args)
        {
            Console.WriteLine(tempConvert());
            Console.WriteLine(lengthCon());
            Console.WriteLine(weightConvert());
            Console.ReadKey();
        }
    }
}
