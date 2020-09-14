using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KonwerterJednostek2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<iKonwerter> converters = new List<iKonwerter>()
            {
                new KonwerterTemperatury(),
                new KonwerterDystansu(),
                new KonwerterMasy(),
                new KonwerterPowierzchni()
            };

            Console.WriteLine("Wybierz konwerter:");

            for(int i = 0; i < converters.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
            }

            int.TryParse(Console.ReadLine(), out int converter_type);

            string units = String.Join(" , ", converters[converter_type - 1].Units);
            Console.WriteLine("Z: " + units);
            string from = Console.ReadLine();

            Console.WriteLine("Do: " + units);
            string to = Console.ReadLine();

            Console.WriteLine("Ile?");
            double.TryParse(Console.ReadLine(), out double value);

            Console.WriteLine(converters[converter_type - 1].convert(value, from, to));
            
            Console.ReadKey();
        }
    }
}
