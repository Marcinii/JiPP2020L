using System;

namespace ConverterApp
{
    class Converter
    {

        protected int number;
        protected double fahrenheit;
        protected double celsius;
        protected double km;
        protected double mil;
        protected double kg;
        protected double pounds;

        public Converter()
        {
            Console.WriteLine("Choose a converter\n Fahrenheit to Celsius - Select 1.\n Celsius to Fahrenheit - Select 2.\n Kilometres to Miles - Select 3.\n Miles to Kilometres - Select 4.\n Pounds to Kilograms - Select 5.\n  Kilograms to Pounds- Select 6.\n");
        }
        public double SelectionPanel()
        {
            Console.WriteLine("Choose which converter you want to use");
            number = int.Parse(Console.ReadLine());
            return number;
        }

        public void ConverterSelect()
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Conversion from Fahrenheit to Celsius.");
                    celsius = double.Parse(Console.ReadLine());
                    fahrenheit = celsius * 1.8 + 32;
                    Console.WriteLine(celsius.ToString() + "Celsius {0}:" + fahrenheit.ToString() + "Degrees Fahrenheit. {0}\n");
                    break;
                case 2:
                    Console.WriteLine("Conversion from Celsius to Fahrenheit.");
                    fahrenheit = double.Parse(Console.ReadLine());
                    celsius = (fahrenheit - 32) / 1.8;
                    Console.WriteLine(fahrenheit.ToString() + "Fahrenheit {0}:" + celsius.ToString() + "Degrees Celsius {0}\n");
                    break;
                case 3:
                    Console.WriteLine("conversion from Kilometers to Miles.");
                    km = double.Parse(Console.ReadLine());
                    mil = km * 0.62137;
                    Console.WriteLine(km.ToString() + "Kilometers {0}:"  + mil.ToString() + "Miles {0}\n");
                    break;
                case 4:
                    Console.WriteLine("Conversion from Miles to Kilometers");
                    mil = double.Parse(Console.ReadLine());
                    km = mil / 0.62;
                    Console.WriteLine(mil.ToString() + "Miles {0}:" + km.ToString() + "Kilometers {0}\n");
                    break;
                case 5:
                    Console.WriteLine("Conversion from Kilograms to Pounds.\n");
                    kg = double.Parse(Console.ReadLine());
                    kg = pounds * 2.20;
                    Console.WriteLine(kg.ToString() + "Kilograms {0}" + pounds.ToString() + "Pounds {0}\n");
                    break;
                case 6:
                    Console.WriteLine("Conversion from Pounds to Kilograms.");
                    pounds = double.Parse(Console.ReadLine());
                    kg = pounds / 2.2046;
                    Console.WriteLine(pounds.ToString() + "Pounds {0}" + kg.ToString() + "Kilograms {0}.\n");
                    break;

                default:
                    Console.WriteLine("How dare you. Try again\n");
                    break;
            }
        }
    }
}