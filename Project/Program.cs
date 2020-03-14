using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IConverter> Converters = new List<IConverter>
            {
                new TempConverter(),
                new WeightConverter(),
                new LengthConverter()
            };

            for(int i = 0; i < Converters.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + Converters[i].Name);
            }



            Console.Write("Wybor: ");
            int choise = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj wartosc: ");
            double value = Double.Parse(Console.ReadLine());
            Console.WriteLine("Z jakiej jednostki nastepuje zamiana?");
            string from = Console.ReadLine();
            Console.WriteLine("Do jakiej jednostki nastepuje zamiana?");
            string to = Console.ReadLine();

            Console.WriteLine("Wynik = " + Converters[choise-1]?.Convert(from, to, value));


        }
    }
}