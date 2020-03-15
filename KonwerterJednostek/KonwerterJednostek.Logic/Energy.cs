using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
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
            Console.Write("\tPodaj wartosc wagi: ");
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
    }
}
