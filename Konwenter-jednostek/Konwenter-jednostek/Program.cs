using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter_jednostek
{
    class Konwenter_Jednostek
    {
        public static double celsusz_na_fahrenheit(double a) { return a * 9 / 5 + 32; }
        public static double fahrenheit_na_celsjusz(double a) { return (a - 32) * 5 / 9; }
        public static double kilometry_na_mile(double a) { return a * 0.62; }
        public static double mile_na_kilometry(double a) { return a * 1.61; }
        public static double kilogramy_na_funty(double a) { return a * 2.20; }
        public static double funty_na_kilogramy(double a) { return a * 0.45; }

        public static void Main()
        {
            Console.WriteLine();
            Console.WriteLine("Konwenter Jednostek ");
            Console.WriteLine();
            Console.WriteLine("1 - C na F");
            Console.WriteLine("2 - F na C");
            Console.WriteLine("3 - km na mile");
            Console.WriteLine("4 - mile na km");
            Console.WriteLine("5 - kg na funty");
            Console.WriteLine("6 - funty na kg");
            int caseSwitch = int.Parse(Console.ReadLine()); ;
            Console.Write("Podaj liczbe: ");
            double liczba = double.Parse(Console.ReadLine()); ;
            switch (caseSwitch)
            {

                case 1:
                    Console.WriteLine(liczba + "°C " + "= " + celsusz_na_fahrenheit(liczba) + "°F");
                    break;

                case 2:
                    Console.WriteLine(liczba + "°F " + "= " + fahrenheit_na_celsjusz(liczba) + "°C");
                    break;

                case 3:
                    Console.WriteLine(liczba + " km " + "= " + kilometry_na_mile(liczba) + " mili ");
                    break;

                case 4:
                    Console.WriteLine(liczba + " mili " + "= " + mile_na_kilometry(liczba) + " km ");
                    break;

                case 5:
                    Console.WriteLine(liczba + " kg " + "= " + kilogramy_na_funty(liczba) + " funta ");
                    break;

                case 6:
                    Console.WriteLine(liczba + " funta " + "= " + funty_na_kilogramy(liczba) + " kg ");
                    break;

            }
            Console.ReadLine();
        }
    }
}
