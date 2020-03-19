using KonwerterJednostek.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class Length : IConverter
    {
        public double value;
        public double k;
        public double m;
        public Length()
        {
            this.value = 0;
            this.m = 0;
            this.k = 0;
        }
        public Length(double value)
        {
            this.value = value;
            this.m = Option1();
            this.k = Option2();
        }

        public string Name => "Długość";

        public List<string> Units => new List<string>
        {
            "km",
            "mi"
        };

        public double Option1()
        {
            double result = this.value * 0.621371;
            return result;
        }
        public double Option2()
        {
            double result = this.value * 1.609344;
            return result;
        }
        public void Info()
        {
            Console.WriteLine("KONWERSJA DLUGOSCI");
            Console.WriteLine("\t(1) Kilometry\t->\tMile");
            Console.WriteLine("\t(2) Mile\t->\tKilometry");
            Console.WriteLine();
            Console.Write("\t");
        }
        public void UnitConv()
        {
            Info();
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tPodaj wartosc odleglosci: ");
            double number = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Length a = new Length(number);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\t" + a.value + " km\t=\t" + a.m + " miles");
                    break;
                case 2:
                    Console.WriteLine("\t" + a.value + " miles\t=\t" + a.k + " km");
                    break;
                default:
                    Console.WriteLine("!!! ERROR !!!");
                    break;
            }
        }

        public string UnitConv(string from, string to, string number)
        {
            bool success = double.TryParse(number, out double inputValue);
            if (!success) { inputValue = 0; }
            Length a = new Length(inputValue);
            if (from == Units[0] && to == Units[1])
            {
                return a.m + " mi";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.k + " km";
            }
            else { return Error.Info(); }
        }
    }
}
