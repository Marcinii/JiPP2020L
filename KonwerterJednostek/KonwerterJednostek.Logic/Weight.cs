using KonwerterJednostek.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class Weight : IConverter
    {
        public double value;
        public double kg;
        public double lb;
        public Weight()
        {
            this.value = 0;
            this.lb = 0;
            this.kg = 0;
        }
        public Weight(double value)
        {
            this.value = value;
            this.lb = Option1();
            this.kg = Option2();
        }

        public string Name => "Waga";

        public List<string> Units => new List<string>
        {
            "lb",
            "kg"
        };

        public double Option1()
        {
            double result = this.value * 2.20462262185;
            return result;
        }
        public double Option2()
        {
            double result = this.value / 2.20462262185;
            return result;
        }
        public void Info()
        {
            Console.WriteLine("KONWERSJA WAGI");
            Console.WriteLine("\t(1) Kilogramy\t->\tFunty");
            Console.WriteLine("\t(2) Funty\t->\tKilogramy");
            Console.WriteLine();
            Console.Write("\t");
        }
        public void UnitConv()
        {
            Info();
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tPodaj wartosc wagi: ");
            double number = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Weight a = new Weight(number);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\t" + a.value + " kg\t=\t" + a.lb + " lb");
                    break;
                case 2:
                    Console.WriteLine("\t" + a.value + " lb\t=\t" + a.kg + " kg");
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
            Weight a = new Weight(inputValue);
            if (from == Units[0] && to == Units[1])
            {
                return a.kg + " kg";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.lb + " lb";
            }
            else { return Error.Info(); }
        }
    }
}