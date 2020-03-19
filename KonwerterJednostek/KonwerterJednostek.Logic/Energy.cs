using KonwerterJednostek.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class Energy : IConverter
    {
        public double value;
        public double jk;
        public double kj;
        public Energy()
        {
            this.value = 0;
            this.jk = 0;
            this.kj = 0;
        }
        public Energy(double value)
        {
            this.value = value;
            this.jk = Option1();
            this.kj = Option2();
        }
        public string Name => "Energia";

        public List<string> Units => new List<string>
        {
            "kJ",
            "kWh"
        };

        public void Info()
        {
            Console.WriteLine("KONWERSJA WAGI");
            Console.WriteLine("\t(1) KiloJoule\t->\tKiloWatoGodziny");
            Console.WriteLine("\t(2) KiloWatoGodziny\t->\tKiloJoule");
            Console.WriteLine();
            Console.Write("\t");
        }

        public double Option1()
        {
            return value / 3600;
        }

        public double Option2()
        {
            return value * 3600;
        }

        public void UnitConv()
        {
            Info();
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tPodaj wartosc jednostki energii: ");
            double number = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Energy a = new Energy(number);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\t" + a.value + " kJ\t=\t" + a.jk + " kWh");
                    break;
                case 2:
                    Console.WriteLine("\t" + a.value + " kWh\t=\t" + a.kj + " kJ");
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
            Energy a = new Energy(inputValue);
            if (from==Units[0] && to == Units[1])
            {
                return a.jk + " kWh";
            }
            else if (from == Units[1] && to == Units[0])
            {
                return a.kj + " kJ";
            }
            else { return Error.Info(); }
        }
    }
}
