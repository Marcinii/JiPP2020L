using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz konwerter:");
            Console.WriteLine("Temperatura (1)");
            Console.WriteLine("Dystans (2)");
            Console.WriteLine("Waga (3)");

            int converter_type = int.Parse(Console.ReadLine());

            if (converter_type == 1)
            {
                Console.WriteLine("Z: C/F");
                string from = Console.ReadLine();
                Console.WriteLine("Na: C/F");
                string to = Console.ReadLine();
                Console.WriteLine("Ile?");
                double many = double.Parse(Console.ReadLine());

                Temperatura converter = new Temperatura();

                double b = converter.convert(many, from, to);
                Console.WriteLine(b);
            }
            else if (converter_type == 2)
            {
                Console.WriteLine("Z: km/miles");
                string from = Console.ReadLine();
                Console.WriteLine("Na: miles/km");
                string to = Console.ReadLine();
                Console.WriteLine("Ile?");
                double many = double.Parse(Console.ReadLine());

                Dystans converter = new Dystans();

                double b = converter.convert(many, from, to);
                Console.WriteLine(b);
            }
            else if (converter_type == 3)
            {

                Console.WriteLine("Z: kg/lbs");
                string from = Console.ReadLine();
                Console.WriteLine("Na: kg/lbs");
                string to = Console.ReadLine();
                Console.WriteLine("Ile?");
                double many = double.Parse(Console.ReadLine());

                Masa converter = new Masa();

                double b = converter.convert(many, from, to);
                Console.WriteLine(b);
            }
            Console.ReadKey();
        }
    }
}
