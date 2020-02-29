using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    class Program
    {

        static double temperatura()
        {
            double f, c;
            Console.WriteLine("Konwersja temperatury: \n1. Celsjusz na Fahrenheita \n2. Fahrenheit na Celsjusza");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Wprowadz temperature w stopniach Celsjusza: ");
                    c = Convert.ToDouble(Console.ReadLine());
                    f = c * 9 / 5 + 32;
                    Console.WriteLine("Temperatura w stopniach Fahernheita to: ");
                    return f;
                case "2":
                    Console.WriteLine("Wprowadz temperature w stopniach Fahrenheita: ");
                    f = Convert.ToDouble(Console.ReadLine());
                    c = (f - 32) * 5 / 9;
                    Console.WriteLine("Temperatura w stopniach Celsjusza to : ");
                    return c;
            }
            return 0;
        }

        static double dystans()
        {
            double km, m;
            Console.WriteLine("Konwersja dystansu: \n1. Kilometry na Mile \n2. Mile na Kilometry");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Wprowadz dystans w kilometrach: ");
                    km = Convert.ToDouble(Console.ReadLine());
                    m = km * 1.6;
                    Console.WriteLine("Dystans w milach to: ");
                    return m;
                case "2":
                    Console.WriteLine("Wprowadz dystans w milach: ");
                    m = Convert.ToDouble(Console.ReadLine());
                    km = m / 1.6;
                    Console.WriteLine("Dystans w kilometrach to: ");
                    return km;
            }
            return 0;
        }

        static double waga()
        {
            double kg, lbs;
            Console.WriteLine("Konwersja wagi: \n1. Kilogramy na Funty \n2. Funty na kilogramy ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Wprowadz wage w kilogramach: ");
                    kg = Convert.ToDouble(Console.ReadLine());
                    lbs = kg * 2.2;
                    Console.WriteLine("Waga w funtach to: ");
                    return lbs;
                case "2":
                    Console.WriteLine("Wprowadz wage w funtach: ");
                    lbs = Convert.ToDouble(Console.ReadLine());
                    kg = lbs / 2.2;
                    Console.WriteLine("Waga w kilogramach to: ");
                    return kg;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(temperatura());
            Console.WriteLine(dystans());
            Console.WriteLine(waga());
            Console.ReadKey();
        }
    }

    
}