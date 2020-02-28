using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp
{
    class Converter1
    {
        static void Main(string[] args)
        {
        start:
            Console.WriteLine("The program replaces units.\n Fahrenheit to Celsius.\n Celsius to Fahrenheit.\n Miles to Kilometers.\n Kilometers to Miles.\n Pounds to kilograms.\n Kilograms to pounds.\n If you need to swap the units, select Y\n.");
            char answer = char.Parse(Console.ReadLine());
            if (answer == 'Y')
            {
                Converter tmp = new Converter();
                tmp.SelectionPanel();
                tmp.ConverterSelect();
                goto start;
            }

            Console.ReadKey();
        }
    }
}