using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static double toCelcius(double a)
        {
            double tempCelcius = 5.0 / 9.0 * (a - 32);
            return tempCelcius;
        }
        static double toFahrenheit(double a)
        {
            double tempFahrenheit = ((9.0 / 5.0) * a) + 32;
            return tempFahrenheit;
        }

        static double toKilometers(double a)
        {
            double distanceKilometers = a * 1609344;
            return distanceKilometers;
        }
        
        static double toMiles(double a)
        {
            double distanceMiles = a * 0.621371192;
            return distanceMiles;
        }

        static double toPounds(double a)
        {
            double weightPounds = a * 2.20462262;
            return weightPounds;
        }

        static double toKilograms(double a)
        {
            double weightKilograms = a * 0.45359237;
            return weightKilograms;
        }

        static void Main(string[] args)
        {
            bool  condition = true;
            while (condition)
            {
                Console.WriteLine("Select converter: ");
                Console.WriteLine("1. Celcius to Fahrenheit.");
                Console.WriteLine("2. Fahrenheit to Celcius.");
                Console.WriteLine("3. Kilometers to miles.");
                Console.WriteLine("4. Miles to kilometers.");
                Console.WriteLine("5. Kilograms to pounds.");
                Console.WriteLine("6. Pounds to kilograms.");
                Console.WriteLine("7. EXIT.");
                Console.Write("Your choice: ");
                
                double caseSwitch = Convert.ToDouble(Console.ReadLine());
 
                switch (caseSwitch)
                {
                    case 1:
                        Console.Write("Temp in Celcius = ");
                        double temp1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Temp in Fahrenheit = " + toFahrenheit(temp1));
                        break;
                    case 2:
                        Console.Write("Temp in Fahrenheit = ");
                        double temp2 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Temp in Celcius = " + toCelcius(temp2));
                        break;
                    case 3:
                        Console.Write("Distance in Kilometers = ");
                        double dist1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Distance in miles = " + toMiles(dist1));
                        break;
                    case 4:
                        Console.Write("Distance in Miles = ");
                        double dist2 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Distance in Kilometers = " + toKilometers(dist2));
                        break;
                    case 5:
                        Console.Write("Weight in Kilograms = ");
                        double weight1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Weight in Pounds = " + toPounds(weight1));
                        break;
                    case 6:
                        Console.Write("Weight in Pounds = ");
                        double weight2 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Weight in Kilograms = " + toKilograms(weight2));
                        break;
                    case 7:
                        condition = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
