using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Converter
    {
        protected double value;
        protected string unit;
        protected double result;
        protected string getValue()
        {
            Console.WriteLine("Type a value and press enter ");
            value = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Select unit of value you entered (c, f, km, mi, kg or lb");
            unit = Console.ReadLine();
            return unit;
        }
        public void convert()
        {
            string userUnit = getValue();
            switch (userUnit)
            {
                case "c":
                    result = (value * 1.8) + 32;
                    Console.WriteLine($"{value}C = {result}F");
                    break;
                case "f":
                    result = (value - 32) / 1.8;
                    Console.WriteLine($"{value}F = {result}C");
                    break;
                case "km":
                    result = value * 0.62137;
                    Console.WriteLine($"{value}km = {result}mi");
                    break;
                case "mi":
                    result = value / 0.62137;
                    Console.WriteLine($"{value}mi = {result}km");
                    break;
                case "kg":
                    result = value * 2.2046;
                    Console.WriteLine($"{value}kg = {result}lb");
                    break;
                case "lb":
                    result = value / 2.2046;
                    Console.WriteLine($"{value}lb = {result}kg");
                    break;
                default:
                    Console.WriteLine("Invalid value");
                    convert();
                    break;
            }
        }
    }
}
