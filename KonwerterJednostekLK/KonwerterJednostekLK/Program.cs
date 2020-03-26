using System;
using System.Collections.Generic;

namespace KonwerterJednostekLK
{
   
    class Program
    {
        static void Main(string[] args){

            List <IConverter> converters = new List<IConverter>(){
                new LenghtConverter(),
                new TemperatureConverter(),
                new MassConverter(),
                new UnitConverter()
            };

            do
            {
                Console.WriteLine("Wybierz, którego konwertera chcesz użyć: ");
                for (int i = 0; i < converters.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[i].getName);
                }
                string inputChoice = Console.ReadLine();
                int index = Convert.ToInt32(inputChoice) - 1;

                Console.WriteLine("Wybierz Z jakiej jednostki: ");

                for (int i = 0; i < converters[index].units.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[index].units[i]);
                }
                string fUnit = Console.ReadLine();
                int fromUnit = int.Parse(fUnit) - 1;


                Console.WriteLine("Wybierz Do jakiej jednostki: ");
                for (int i = 0; i < converters[index].units.Count; i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1, converters[index].units[i]);
                }
                string tUnit = Console.ReadLine();
                int ToUnit = int.Parse(tUnit) - 1;

                Console.WriteLine("Podaj liczbę do konwersji: ");
                string getValue = Console.ReadLine();
                float value = float.Parse(getValue);

                float result = converters[index].Convert(fromUnit, ToUnit, value);

                Console.WriteLine("Wynik konwersji: " + result);


                Console.WriteLine("----------------------------------\n");
            } while (true);

        }
    }
}

            

 