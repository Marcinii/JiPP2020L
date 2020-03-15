using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConverter> converters = new List<IConverter>()
            {
            new WeightConverter(),
            new VolumeConverter(),
            new LenghtConverter(),
            new TemperatureConverter()
            };

            Console.WriteLine("Konwerter jednostek\r");
            Console.WriteLine("------------------------\n");
            char czyKontynuowac = 't';

            while (czyKontynuowac == 't')
            {
                Console.WriteLine("Jaką operację chcesz wykonać? Wybierz z poniższej listy:");

                for (int i = 0; i < converters.Count; i++)
                {
                    Console.Write("({0}) {1} \n", i + 1, converters[i].Name);
                }

                string choiceS = Console.ReadLine();
                int choice = int.Parse(choiceS);

                

                for (int i = 0; i < converters[choice-1].Units.Count; i++)
                {
                    Console.WriteLine(converters[choice-1].Units[i].ToString());
                }

                Console.WriteLine("Jaką jednostkę przekonwertować?");
                string unitFrom = Console.ReadLine();

                Console.WriteLine("Jaką jednostkę chcesz otrzymać?");
                string unitTo = Console.ReadLine();

                Console.WriteLine("Podaj ile " + unitFrom + " chcesz przekonwertować");
                string valueS = Console.ReadLine();
                decimal value = decimal.Parse(valueS);

                decimal result = converters[choice - 1].Convert(unitFrom, unitTo, value);

                Console.WriteLine("Wynik: " + result + unitTo);

                Console.Write("Czy chcesz wykonać kolejną konwersję jednostek? (t/n)");
                czyKontynuowac = Convert.ToChar(Console.ReadLine());

            }
        }
    }
}
