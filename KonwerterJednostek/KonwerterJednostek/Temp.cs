using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Temp : IConverter
    {
        public double value;
        public double cf;
        public double fc;
        private double ck;
        private double kc;
        private double fk;
        private double kf;
        public Temp()
        {
            this.value = 0;
            this.cf = 0;
            this.fc = 0;
            this.ck = 0;
            this.kc = 0;
            this.fk = 0;
            this.kf = 0;
        }
        public Temp(double value)
        {
            this.value = value;
            this.cf = Option1();
            this.fc = Option2();
            this.ck = Option3();
            this.kc = Option4();
            this.fk = Option5();
            this.kf = Option6();
        }

        public string Name => "Temperatura";

        public List<string> Units => new List<string>
        {
            "stC",
            "F",
            "K"
        };

        public double Option1()
        {
            double result = this.value * 9 / 5 + 32;
            return result;
        }
        public double Option2()
        {
            double result = (this.value - 32) * 5 / 9;
            return result;
        }
        public double Option3()
        {
            return this.value + 273.15;
        }
        public double Option4()
        {
            return this.value - 273.15;
        }
        public double Option5()
        {
            return (this.value - 32) * 5 / 9 + 273.15;
        }
        public double Option6()
        {
            return (this.value - 273.15) * 9 / 5 + 32;
        }
        public void Info()
        {
            Console.WriteLine("KONWERSJA TEMPERATURY");
            Console.WriteLine("\t(1) Celsjusz\t->\tFahrenheit");
            Console.WriteLine("\t(2) Fahrenheit\t->\tCelsjusz");
            Console.WriteLine("\t(3) Celsjusz\t->\tKelwin");
            Console.WriteLine("\t(4) Kelwin\t->\tCelsjusz");
            Console.WriteLine("\t(5) Fahrenheit\t->\tKelwin");
            Console.WriteLine("\t(6) Kelwin\t->\tFahrenheit");
            Console.WriteLine();
            Console.Write("\t");
        }
        public void UnitConv()
        {
            Info();

            string test = Console.ReadLine();

            int choice = Convert.ToInt32(test);
            Console.Write("\tPodaj wartosc temperatury: ");
            double number = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
            Temp a = new Temp(number);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\t" + a.value + " stC\t=\t" + a.cf + " F");
                    break;
                case 2:
                    Console.WriteLine("\t" + a.value + " F\t=\t" + a.fc + " stC");
                    break;
                case 3:
                    Console.WriteLine("\t" + a.value + " stC\t=\t" + a.ck + " K");
                    break;
                case 4:
                    Console.WriteLine("\t" + a.value + " K\t=\t" + a.kc + " stC");
                    break;
                case 5:
                    Console.WriteLine("\t" + a.value + " F\t=\t" + a.fk + " K");
                    break;
                case 6:
                    Console.WriteLine("\t" + a.value + " K\t=\t" + a.kf + " F");
                    break;
                default:
                    Console.WriteLine("!!! ERROR !!!");
                    break;
            }
        }
    }
}
