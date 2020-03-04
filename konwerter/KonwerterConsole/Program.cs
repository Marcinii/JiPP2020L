using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    class Program
    {
        static void Main(string[] args)
        {
            string from_type, to_type;
            decimal value;
            int choice;
            List<IConverter> converters = new List<IConverter>()
            {
                new MassConv(),
                new TemperatureConv(),
                new LenghConv(),
                new StorageConv()
            };
            bool shouldContinue = true;
            while (shouldContinue)
            {
                Console.WriteLine("Wybierz opcję: ");
                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].name);
                }
                while (int.TryParse(Console.ReadLine(), out choice) == false)
                {
                    Console.WriteLine("Podaj poprawną wartość ");
                }
                converters[choice - 1].List_unit();
                Console.WriteLine("Podaj jednostke z: ");
                from_type = Console.ReadLine();
                Console.WriteLine("Podaj jednostkę do: ");
                to_type = Console.ReadLine();
                Console.WriteLine("Podaj wartość do konwersji: ");
                string intValue = Console.ReadLine();
                while (decimal.TryParse(intValue, out value) == false)
                {
                    Console.WriteLine("Podaj poprawną wartość do konwersji: ");
                    intValue = Console.ReadLine();
                }
                converters[choice - 1].Data_and_convert(from_type, to_type, value);
                Console.WriteLine("Czy chcesz kontynuować? (t/n)");
                string choicecontinue = Console.ReadLine();
                if(choicecontinue == "n")
                {
                    shouldContinue = false;
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }    
}
