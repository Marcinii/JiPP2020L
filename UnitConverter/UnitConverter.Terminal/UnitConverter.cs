using System;
using System.Collections.Generic;
using UnitConverter.Library;

namespace UnitConverter.Terminal
{
    public class UnitConverter
    {
        private List<IConverter> Converters => new List<IConverter>
        {
            new DistanceConverter(),
            new WeightConverter(),
            new TemperatureConverter(),
        };

        public string OtherUnit(string unit, IConverter converter)
        {
            foreach (string u in converter.Units)
            {
                if (u != unit)
                {
                    return u;
                }
            }
            return unit;
        }

        public UnitConverter()
        {
            ShowMenu();

            while (true)
            {
                GetMenuValueFromUser();
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Welcome to Unit Converter, Available units are:");
            Console.WriteLine("Distance - km, mi");
            Console.WriteLine("Weight - kg, lb");
            Console.WriteLine("Temperature - C, F");
        }

        public void GetMenuValueFromUser()
        {
            double value;
            while (true)
            {
                Console.WriteLine("Please insert value: ");
                string val = Console.ReadLine();
                try
                {
                    value = Double.Parse(val);
                    break;
                }
                catch (FormatException)
                { }
            }
            Console.WriteLine("Please insert unit: ");
            string unit = Console.ReadLine();

            foreach (IConverter converter in Converters)
            { 
                if (converter.Units.Contains(unit))
                {
                    double outValue = converter.Convert(value, unit);
                    Console.WriteLine(value + " " + unit + " = " + outValue + OtherUnit(unit, converter));
                    break;
                }
            }
        }
    }
}