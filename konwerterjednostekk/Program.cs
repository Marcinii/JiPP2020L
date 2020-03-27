using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using konwerter.logic;

namespace konwerterjednostekk
{
    class Program
    {

        

        static void Main(string[] args)
        {

            List<Ikonwerter> converters = new List<Ikonwerter>()
            {
                new temp_converter(),
                new length_converter(),
                new weight_conventer(),
                new data_converter(),
            };

            Console.WriteLine("Wybierz rodzaj konwersji:");

            for (int i = 0; i < converters.Count; i++)
            {
                Console.WriteLine("({0}) {1}", i + 1, converters[i].Name);
            }
            
            int inputChoice = Convert.ToInt32(Console.ReadLine()) - 1;

            for (int i = 0; i < converters[inputChoice].Units.Count; i++)
            {
                Console.WriteLine(converters[inputChoice].Units[i].ToString());
            }


            Console.WriteLine("Podaj jednostek z: ");
            string unitFrom = Console.ReadLine();

            Console.WriteLine("Podaj jednostkę do: ");
            string unitTo = Console.ReadLine();

            Console.WriteLine("Podaj liczbę do konwersji: ");
            string inputValue = Console.ReadLine();


            int choice = inputChoice; // TryParse!
            decimal value = decimal.Parse(inputValue); // TryParse!

            Console.WriteLine("Wynik konwersji: {0}", converters[choice].Convert(unitFrom, unitTo, value));

            System.Console.ReadKey();
        }
    }
}
