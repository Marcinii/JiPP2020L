using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unitconverter.logic;

namespace lesson1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Iconverter> converters = new List<Iconverter>()
            {
                new c_lenght(),
                new c_temperature(),
                new c_weight(),
                new c_capacity()
            };

            Console.WriteLine("Witaj w kalkulatorze jednostek! \n Wybierz, co chcesz przeliczyć:");
            string choose;
            do
            {
                int number_list = 0;
                foreach(Iconverter converter in converters)
                {
                    number_list++;
                    Console.WriteLine(number_list + ") " + converter.name);
                }
                choose = Console.ReadLine();
                int converted_choose = parse.convert_string_to_int(choose);
                Console.WriteLine("Lista dostępnych jednostek, pomiędzy którymi możesz przprowadzać konwersje:");
                foreach (string units in converters[converted_choose - 1].units_names)
                {
                    number_list++;
                    Console.WriteLine(units);
                }
                Console.WriteLine("Podaj jednostki z których konwertujesz:");
                string from = Console.ReadLine();
                Console.WriteLine("Podaj jednostki do których konwertujesz:");
                string to = Console.ReadLine();
                Console.WriteLine("Podaj wartosc do przekonwertowania:");
                string value = Console.ReadLine();
                decimal converted_value = parse.convert_string_to_decimal(value);
                decimal result = converters[converted_choose - 1].operation(from, to, converted_value);
                Console.WriteLine(converted_value + from + " = " + result + to);

            } while (choose != "0");
        }
    }
}